using Microsoft.AspNetCore.Mvc;
using nbaDemo.API.Filters;
using nbaDemo.Business.Abstracts;
using System.Threading.Tasks;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService positionService;

        public PositionsController(IPositionService positionService)
        {
            this.positionService = positionService;
        }

        [HttpGet]
        [TypeFilter(typeof(LogInfo<PositionsController>))]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetPositions()
        {
            var positions = await positionService.GetAllPositions();

            return Ok(positions);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(CheckExistingEntity<IPositionService>))]
        [TypeFilter(typeof(LogInfo<PositionsController>))]
        public async Task<IActionResult> GetPositionByID(int id)
        {
            var position = await positionService.GetPositionById(id);

            return Ok(position);
        }
    }
}
