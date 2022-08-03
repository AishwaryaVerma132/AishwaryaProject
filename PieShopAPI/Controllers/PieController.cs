using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("Pie")]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()      // All Pies List
        {
            try
            {
                var pies = _pieRepository.AllPies;
                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpGet]
        [Route("PiesOfTheWeek")]
        public IActionResult PiesOfTheWeek()
        {
            try
            {
                var PiesOfTheWeek = _pieRepository.PiesOfTheWeek;
                return Ok(PiesOfTheWeek);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpGet("{id}" , Name = "Details")]
        public IActionResult Details(int id)
        {
            try
            {
                var GetPieById = _pieRepository.GetPieById(id);
                if(GetPieById == null)
                {
                    return NotFound("Pie Not Found");
                }
                return Ok(GetPieById);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("AllCategories")]
        public IActionResult AllCategories()
        {
            try
            {
                var AllCategories = _categoryRepository.AllCategories;
                return Ok(AllCategories);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("GetCategory")]
        public ActionResult<IEnumerable<Category>> GetCategory(int categoryId = 1)
        {
            try
            {
                var Category = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryId);
                return Ok(Category);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("ListDescending")]
        public IActionResult ListDescending()      
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderByDescending(p => p.Price);
                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpGet]
        [Route("ListAscending")]
        public IActionResult ListAscending()      
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderBy(p => p.Price);
                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpPost]                         
        [Route("InsertPie")]
        public IActionResult InsertPie(Pie pie)
        {
            try
            {
                var InsertedPie = this._pieRepository.InsertPie(pie);
                return Ok(InsertedPie); 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {
            try
            {
                var InsertedCategory = this._categoryRepository.InsertCategory(category);
                return Ok(InsertedCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]                         
        [Route("UpdatePie")]
        public IActionResult UpdatePie(Pie pie)
        {
            try
            {
                var UpdatededPie = this._pieRepository.UpdatePie(pie);
                return Ok(UpdatededPie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpPut]                         
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                var UpdatededCategory = this._categoryRepository.UpdateCategory(category);
                return Ok(UpdatededCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpDelete]
        [Route("DeletePie")]
        public IActionResult DeletePie(int PieID)
        {
            try
            {
                var pies = this._pieRepository.AllPies.FirstOrDefault(pie => pie.PieId == PieID);
                if (pies == null)
                {
                    return BadRequest("Pie ID Not Found");
                }
                var DeletingPie = this._pieRepository.DeletePie(PieID);
                return Ok(DeletingPie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int CategoryID)
        {
            try
            {
                var category = this._categoryRepository.AllCategories.FirstOrDefault(pie => pie.CategoryId == CategoryID);
                if (category == null)
                {
                    return BadRequest("Category ID Not Found");
                }
                var DeletingPie = this._categoryRepository.DeleteCategory(CategoryID);
                return Ok(DeletingPie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }
    }
}
