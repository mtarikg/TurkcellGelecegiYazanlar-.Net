using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests.PlayerRequests;
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
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly ITeamService teamService;
        private readonly IPositionService positionService;
        private readonly IMapper mapper;

        public PlayersController(IPlayerService playerService, ITeamService teamService, IPositionService positionService, IMapper mapper)
        {
            this.playerService = playerService;
            this.teamService = teamService;
            this.positionService = positionService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var playerResponses = await playerService.GetAllPlayers();
            var positions = await positionService.GetAllPositions();
            var positionPlayers = PlayersControllerHelperMethods.GetPositionPlayers(positions, playerResponses);
            var model = new PlayersViewModel { PositionPlayers = positionPlayers };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<SelectListItem> selectTeams = await PlayersControllerHelperMethods.GetTeamsForDropDownList(teamService);
            List<SelectListItem> selectPositions = await PlayersControllerHelperMethods.GetPositionsForDropDownList(positionService);
            ViewBag.Teams = selectTeams;
            ViewBag.Positions = selectPositions;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Country,LastAttended,Height,Weight,JerseyNumber,Experience,Age,DraftInfo,DateOfBirth,ProfileImage,TeamID,PositionID")] PlayerAddRequest request)
        {
            if (ModelState.IsValid)
            {
                int addedPlayerID = await playerService.AddPlayer(request);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await playerService.IsExist(id))
            {
                Player player = await playerService.GetPlayerById(id);
                PlayerListResponse response = mapper.Map<PlayerListResponse>(player);
                PlayerEditRequest request = mapper.Map<PlayerEditRequest>(response);
                List<SelectListItem> selectTeams = await PlayersControllerHelperMethods.GetTeamsForDropDownList(teamService);
                List<SelectListItem> selectPositions = await PlayersControllerHelperMethods.GetPositionsForDropDownList(positionService);
                ViewBag.Teams = selectTeams;
                ViewBag.Positions = selectPositions;

                return View(request);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,FullName,Height,Weight,JerseyNumber,Experience,Age,ProfileImage,TeamID,PositionID")] PlayerEditRequest request)
        {
            if (ModelState.IsValid)
            {
                int affectedRowsCount = await playerService.EditPlayer(request);
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
            var player = await playerService.GetPlayerById(id);
            var team = await PlayersControllerHelperMethods.GetPlayerTeam(player, teamService);
            var position = await PlayersControllerHelperMethods.GetPlayerPosition(player, positionService);
            var model = new SinglePlayerViewModel { Player = player, Team = team, Position = position };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await playerService.IsExist(id))
            {
                var player = await playerService.GetPlayerById(id);
                var playerListResponse = mapper.Map<PlayerListResponse>(player);
                return View(playerListResponse);
            }

            return NotFound();
        }

        [HttpPost]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> DeleteOk(int id)
        {
            await playerService.DeletePlayer(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
