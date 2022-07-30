using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("Pie")]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public PieController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
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
                return Ok();
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }
    }
}
