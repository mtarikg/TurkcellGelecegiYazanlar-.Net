using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests.TeamRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using nbaDemo.Web.Controllers.ControllersHelperMethods;
using nbaDemo.Web.Models;
using nbaDemo.Web.Subclasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Web.Controllers
{
    [CustomAuthorize(AuthorizeRoles.Administrator, AuthorizeRoles.Editor)]
    public class TeamsController : Controller
    {
        private readonly ITeamService teamService;
        private readonly IConferenceService conferenceService;
        private readonly IDivisionService divisionService;
        private readonly IMapper mapper;

        public TeamsController(ITeamService teamService, IConferenceService conferenceService, IDivisionService divisionService, IMapper mapper)
        {
            this.teamService = teamService;
            this.conferenceService = conferenceService;
            this.divisionService = divisionService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTeams = await teamService.GetAllTeams();
            var allDivisions = await divisionService.GetAllDivisions();
            var divisionTeams = TeamsControllerHelperMethods.GetDivisionTeams(allDivisions, allTeams);

            var model = new TeamsViewModel
            {
                DivisionTeams = divisionTeams
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectConferences = await TeamsControllerHelperMethods.GetConferencesForDropDownList(conferenceService);
            List<SelectListItem> selectDivisions = await TeamsControllerHelperMethods.GetDivisionsForDropDownList(divisionService);
            ViewBag.Conferences = selectConferences;
            ViewBag.Divisions = selectDivisions;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Logo,FoundationYear,CurrentOwner,HeadCoach,Arena,DivisionID,ConferenceID")] TeamAddRequest request)
        {
            if (ModelState.IsValid)
            {
                int addedTeamID = await teamService.AddTeam(request);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await teamService.IsExist(id))
            {
                Team team = await teamService.GetTeamById(id);
                TeamEditRequest request = mapper.Map<TeamEditRequest>(team);
                List<SelectListItem> selectConferences = await TeamsControllerHelperMethods.GetConferencesForDropDownList(conferenceService);
                List<SelectListItem> selectDivisions = await TeamsControllerHelperMethods.GetDivisionsForDropDownList(divisionService);
                ViewBag.Conferences = selectConferences;
                ViewBag.Divisions = selectDivisions;

                return View(request);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,Name,Logo,CurrentOwner,HeadCoach,Arena,DivisionID,ConferenceID")] TeamEditRequest request)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = await teamService.EditTeam(request);
                if (affectedRowsCount > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest();
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var team = await teamService.GetTeamById(id);
            var conference = await conferenceService.GetConferenceById(team.ConferenceID);
            var division = await divisionService.GetDivisionById(team.DivisionID);
            var model = new SingleTeamViewModel { Team = team, Conference = conference, Division = division };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await teamService.IsExist(id))
            {
                var team = await teamService.GetTeamById(id);
                var teamListResponse = mapper.Map<TeamListResponse>(team);

                return View(teamListResponse);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteOk(int id)
        {
            await teamService.DeleteTeam(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
