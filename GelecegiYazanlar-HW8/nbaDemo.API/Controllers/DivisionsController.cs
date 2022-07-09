using Microsoft.AspNetCore.Mvc;
using nbaDemo.API.Filters;
using nbaDemo.Business.Abstracts;
using System.Threading.Tasks;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly IDivisionService divisionService;

        public DivisionsController(IDivisionService divisionService)
        {
            this.divisionService = divisionService;
        }

        [HttpGet]
        [TypeFilter(typeof(LogInfo<DivisionsController>))]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetDivisions()
        {
            var divisions = await divisionService.GetAllDivisions();

            return Ok(divisions);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(LogInfo<DivisionsController>))]
        [TypeFilter(typeof(CheckExistingEntity<IDivisionService>))]
        public async Task<IActionResult> GetDivisionByID(int id)
        {
            var division = await divisionService.GetDivisionById(id);

            return Ok(division);
        }
    }
}
