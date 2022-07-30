using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Pie_Shop.Models;
using My_Pie_Shop.ViewModels;

namespace My_Pie_Shop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly IMapper mapper;

        public PieController(IPieRepository pieRepository, IMapper mapper)
        {
            this._pieRepository = pieRepository;
            this.mapper = mapper;
        }
        public IActionResult List(int CategoryId = 0)
        {
            //var pies = _pieRepository.AllPies;
            IEnumerable<Pie> pies;
            PieListViewModel pieListViewModel = new PieListViewModel();
            

            if (CategoryId > 0)
            {
                pies = _pieRepository.AllPies.Where(pie => pie.CategoryId == CategoryId);
                pieListViewModel.CurrentCategory = pies.First().Category.CategoryName;
            }
            else
            {
                pies = _pieRepository.AllPies;
                pieListViewModel.CurrentCategory = "All Pies Of Pie Pleasure";
            }
            pieListViewModel.Pies = pies;
                       
            return View(pieListViewModel);           
        }

        public IActionResult MiniPie()
        {
            var pies = _pieRepository.AllPies;
            var miniPies = mapper.Map<PieMini[]>(pies);
            return View(miniPies);
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
        
        [Authorize]
        public IActionResult AddToShoppingCart(int id)
        {
            var GetPie = _pieRepository.GetPieById(id);
            return View(GetPie);
        }
    }
}
