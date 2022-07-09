using Microsoft.AspNetCore.Mvc;
using nbaDemo.API.Filters;
using nbaDemo.API.Subclasses;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests.PlayerRequests;
using nbaDemo.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        [TypeFilter(typeof(LogInfo<PlayersController>))]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await playerService.GetAllPlayers();
            players.ToList().ForEach(player => player.CreatedTime = DateTime.Now);

            return Ok(players);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(LogInfo<PlayersController>))]
        [TypeFilter(typeof(CheckExistingEntity<IPlayerService>))]
        public async Task<IActionResult> GetPlayerByID(int id)
        {
            var player = await playerService.GetPlayerById(id);

            return Ok(player);
        }

        [CustomAuthorize(AuthorizeRoles.Administrator)]
        [TypeFilter(typeof(LogInfo<PlayersController>))]
        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerAddRequest request)
        {
            if (ModelState.IsValid)
            {
                var addedPlayerID = await playerService.AddPlayer(request);

                return CreatedAtAction(nameof(GetPlayerByID), routeValues: new { id = addedPlayerID }, null);
            }

            return BadRequest(ModelState);
        }

        [CustomAuthorize(AuthorizeRoles.Administrator, AuthorizeRoles.Editor)]
        [HttpPut]
        [TypeFilter(typeof(CheckExistingEntity<IPlayerService>))]
        [TypeFilter(typeof(LogInfo<PlayersController>))]
        public async Task<IActionResult> UpdatePlayer(int id, PlayerEditRequest request)
        {
            if (ModelState.IsValid)
            {
                await playerService.EditPlayer(request);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [CustomAuthorize(AuthorizeRoles.Administrator)]
        [HttpDelete]
        [TypeFilter(typeof(CheckExistingEntity<IPlayerService>))]
        [TypeFilter(typeof(LogInfo<PlayersController>))]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            await playerService.DeletePlayer(id);

            return Ok();
        }
    }
}