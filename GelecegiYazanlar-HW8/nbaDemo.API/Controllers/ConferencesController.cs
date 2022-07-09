using Microsoft.AspNetCore.Mvc;
using nbaDemo.API.Filters;
using nbaDemo.API.Subclasses;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly IConferenceService conferenceService;
        
        public ConferencesController(IConferenceService conferenceService)
        {
            this.conferenceService = conferenceService;
        }

        [HttpGet]
        [TypeFilter(typeof(LogInfo<ConferencesController>))]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetConferences()
        {
            var conferences = await conferenceService.GetAllConferences();

            return Ok(conferences);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(CheckExistingEntity<IConferenceService>))]
        [TypeFilter(typeof(LogInfo<ConferencesController>))]
        public async Task<IActionResult> GetConferenceByID(int id)
        {
            var conference = await conferenceService.GetConferenceById(id);

            return Ok(conference);
        }

        [HttpPut]
        [TypeFilter(typeof(CheckExistingEntity<IConferenceService>))]
        [TypeFilter(typeof(LogInfo<ConferencesController>))]
        [CustomAuthorize(AuthorizeRoles.Administrator, AuthorizeRoles.Editor)]
        public async Task<IActionResult> UpdateConference(int id, ConferenceEditRequest request)
        {
            if (ModelState.IsValid)
            {
                await conferenceService.EditConference(request);

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
