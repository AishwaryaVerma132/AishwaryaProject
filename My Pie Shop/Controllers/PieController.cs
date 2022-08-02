using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Pie_Shop.Models;
using My_Pie_Shop.ViewModels;
using Newtonsoft.Json;

namespace My_Pie_Shop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper mapper;

        private readonly IConfiguration configuration;

        string baseAddress;

        public PieController(IPieRepository pieRepository, IMapper mapper , IConfiguration configuration, ICategoryRepository categoryRepository)
        {
            this._pieRepository = pieRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.baseAddress = configuration.GetValue<string>("BaseAddress");
            _categoryRepository = categoryRepository;
        }

        private IEnumerable<Pie> GetAllPies()
        {
            var pies = PieAPIData.GetApiData(baseAddress + "List");
            return pies.Result;
        }
        public IActionResult List(int CategoryId = 0)
        {
            IEnumerable<Pie> pies;
            PieListViewModel pieListViewModel = new PieListViewModel();            

            if (CategoryId > 0)
            {
                pies = GetAllPies().Where(pie => pie.CategoryId == CategoryId);
                pieListViewModel.CurrentCategory = "Category";
            }
            else
            {
                pies = GetAllPies();
                pieListViewModel.CurrentCategory = "All Pies Of Pie Pleasure";
            }
            pieListViewModel.Pies = pies;                       
            return View(pieListViewModel);           
        }

        public IActionResult MiniPie()   // Using Mapper
        {
            var pies = _pieRepository.AllPies;
            var miniPies = mapper.Map<PieMini[]>(pies);
            return View(miniPies);
        }

        public async Task<IActionResult> PiesOfTheWeek()
        {
            var pies = PieAPIData.GetApiData(baseAddress + "PiesOfTheWeek");
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies.Result;

            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var GetPieById = PieAPIData.GetApiData(baseAddress + "List").Result.FirstOrDefault(p => p.PieId == id);
            return View(GetPieById);     
        }


        public async Task<IActionResult> ListAscending()
        {
            var pies = PieAPIData.GetApiData(baseAddress + "ListAscending");
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies.Result;

            return View(pieListViewModel);
        }

        public async Task<IActionResult> ListDescending()
        {
            var pies = PieAPIData.GetApiData(baseAddress + "ListDescending");
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies.Result;

            return View(pieListViewModel);
        }

        public IActionResult AllCategories()
        {
            var categories = PieAPIData.GetCategoryApiData(baseAddress + "AllCategories");          
            return View(categories.Result);
        }

        [Authorize]
        public ViewResult Create()
        {
            var categories = PieAPIData.GetCategoryApiData(baseAddress + "AllCategories");
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories.Result)
            {
                categoryItems.Add(new SelectListItem {Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            ViewBag.categoryItems = categoryItems;

            return View();
        }

        public async Task<IActionResult> CreatePie(Pie pie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(baseAddress + "InsertPie", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");        
        }

        public ViewResult CreateCategory()
        {
            return View();
        }

        public async Task<IActionResult> InsertCategory(Category category)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(baseAddress + "InsertCategory", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategories");
        }

        [Authorize]
        public ViewResult Edit(int id) 
        {
            var pies = PieAPIData.GetApiData(baseAddress + "List").Result.FirstOrDefault(p => p.PieId == id);
            var categories = PieAPIData.GetCategoryApiData(baseAddress + "AllCategories");
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories.Result)
            {
                categoryItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            ViewBag.categoryItems = categoryItems;
            return View(pies);
        }

        public async Task<IActionResult> UpdatePie(Pie pie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(baseAddress + "UpdatePie", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
          
        }

        public ViewResult EditCategory(int id)
        {
            var category = PieAPIData.GetCategoryApiData(baseAddress + "AllCategories").Result.FirstOrDefault(p => p.CategoryId == id);
            return View(category);
        }

        public async Task<IActionResult> UpdateCategory(Category category)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(baseAddress + "UpdateCategory", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategories");

        }
        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(baseAddress + "DeletePie?PieID=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(baseAddress + "DeleteCategory?CategoryID=" + id)) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategories");
        }

        [Authorize]
        public IActionResult AddToShoppingCart(int id)
        {
            var GetPie = _pieRepository.GetPieById(id);
            return View(GetPie);
        }
    }
}
