using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using nbaDemo.Web.Controllers.ControllersHelperMethods;
using nbaDemo.Web.Models;
using nbaDemo.Web.Subclasses;
using System.Threading.Tasks;

namespace nbaDemo.Web.Controllers
{
    [CustomAuthorize(AuthorizeRoles.Administrator, AuthorizeRoles.Editor)]
    public class StandingsController : Controller
    {
        private readonly IConferenceService conferenceService;
        private readonly ITeamService teamService;
        private readonly ITeamService divisionService;
        private readonly IMapper mapper;

        public StandingsController(IConferenceService conferenceService, ITeamService teamService, ITeamService divisionService, IMapper mapper)
        {
            this.conferenceService = conferenceService;
            this.teamService = teamService;
            this.divisionService = divisionService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allConferences = await conferenceService.GetAllConferences();
            var allTeams = await teamService.GetAllTeams();
            var conferenceTeams = StandingsControllerHelperMethods.GetConferenceTeams(allConferences, allTeams);

            var model = new StandingsViewModel
            {
                ConferenceTeams = conferenceTeams,
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await conferenceService.IsExist(id))
            {
                Conference conference = await conferenceService.GetConferenceById(id);
                ConferenceEditRequest request = mapper.Map<ConferenceEditRequest>(conference);

                return View(request);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,Logo")] ConferenceEditRequest request)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = await conferenceService.EditConference(request);
                if (affectedRowsCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest();
            }

            return View();
        }
    }
}
