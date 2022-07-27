using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Pie_Shop.Models;
using My_Pie_Shop.ViewModels;

namespace My_Pie_Shop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            this._pieRepository = pieRepository;
        }
        public IActionResult List()
        {

            var pies = _pieRepository.AllPies;
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese cakes ";


            return View(pieListViewModel);
        }

        public IActionResult PiesOfTheWeek()
        {
            var PiesOfTheWeek = _pieRepository.PiesOfTheWeek;
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = PiesOfTheWeek;

            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var GetPieById = _pieRepository.GetPieById(id);
            return View(GetPieById);     
        }

        public IActionResult FruitPieList()
        {
            var FruitPieList = _pieRepository.FruitPie;
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = FruitPieList;

            return View(pieListViewModel);
        }

        public IActionResult CheeseCakeList()
        {
            var CheeseCakeList = _pieRepository.CheeseCake;
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = CheeseCakeList;

            return View(pieListViewModel);
        }

        public IActionResult SeasonalPieList()
        {
            var SeasonalPieList = _pieRepository.SeasonalPie;
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = SeasonalPieList;

            return View(pieListViewModel);
        }

        /*public ViewResult List(int categoryID)
        {
            IEnumerable<Pie> pies;
            if(categoryID > 0)
            {
                pies = _pieRepository.AllPies.Where(pie => pie.CategoryId == categoryId);
            }
            else
            {
                pies = _pieRepository.AllPies;
            }
            return View(pies);

        }*/

        [Authorize]
        public IActionResult AddToShoppingCart(int id)
        {
            var GetPie = _pieRepository.GetPieById(id);
            return View(GetPie);
        }
    }
}
