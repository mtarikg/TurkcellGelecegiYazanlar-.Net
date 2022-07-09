using Microsoft.AspNetCore.Mvc;
using nbaDemo.API.Filters;
using nbaDemo.API.Subclasses;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Requests.TeamRequests;
using nbaDemo.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace nbaDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [TypeFilter(typeof(LogInfo<TeamsController>))]
        [ResponseCache(Duration = 60, VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await teamService.GetAllTeams();
            teams.ToList().ForEach(team => team.CreatedTime = DateTime.Now);

            return Ok(teams);
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(CheckExistingEntity<ITeamService>))]
        [TypeFilter(typeof(LogInfo<TeamsController>))]
        public async Task<IActionResult> GetTeamByID(int id)
        {
            var team = await teamService.GetTeamById(id);

            return Ok(team);
        }

        [HttpPost]
        [CustomAuthorize(AuthorizeRoles.Administrator)]
        [TypeFilter(typeof(LogInfo<TeamsController>))]
        public async Task<IActionResult> AddTeam(TeamAddRequest request)
        {
            if (ModelState.IsValid)
            {
                var addedTeamID = await teamService.AddTeam(request);

                return CreatedAtAction(nameof(GetTeamByID), routeValues: new { id = addedTeamID }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [TypeFilter(typeof(CheckExistingEntity<ITeamService>))]
        [TypeFilter(typeof(LogInfo<TeamsController>))]
        [CustomAuthorize(AuthorizeRoles.Administrator, AuthorizeRoles.Editor)]
        public async Task<IActionResult> UpdateTeam(int id, TeamEditRequest request)
        {
            if (ModelState.IsValid)
            {
                await teamService.EditTeam(request);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        [TypeFilter(typeof(CheckExistingEntity<ITeamService>))]
        [TypeFilter(typeof(LogInfo<TeamsController>))]
        [CustomAuthorize(AuthorizeRoles.Administrator)]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await teamService.DeleteTeam(id);

            return Ok();
        }
    }
}
