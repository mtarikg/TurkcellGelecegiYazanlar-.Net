using Microsoft.AspNetCore.Mvc.Rendering;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nbaDemo.Web.Controllers.ControllersHelperMethods
{
    public static class PlayersControllerHelperMethods
    {
        public static IDictionary<Position, IList<PlayerListResponse>> GetPositionPlayers(ICollection<Position> allPositions, ICollection<PlayerListResponse> allPlayers)
        {
            var playersTeamsDictionary = new Dictionary<Position, IList<PlayerListResponse>>();

            foreach (var position in allPositions)
            {
                playersTeamsDictionary.Add(position, null);
                var positionPlayersList = new List<PlayerListResponse>();

                foreach (var player in allPlayers)
                {
                    if (position.ID == player.PositionID)
                    {
                        positionPlayersList.Add(player);

                        if (!playersTeamsDictionary.ContainsKey(position))
                        {
                            playersTeamsDictionary.Add(position, positionPlayersList);
                            break;
                        }

                        playersTeamsDictionary[position] = positionPlayersList;
                    }
                }
            }

            return playersTeamsDictionary;
        }

        public static async Task<List<SelectListItem>> GetTeamsForDropDownList(ITeamService teamService)
        {
            var allTeams = await teamService.GetAllTeams();
            var items = new List<SelectListItem>();
            allTeams.ToList().ForEach(team => items.Add(new SelectListItem { Text = team.Name, Value = team.ID.ToString() }));

            return items;
        }

        public static async Task<List<SelectListItem>> GetPositionsForDropDownList(IPositionService positionService)
        {
            var allPositions = await positionService.GetAllPositions();
            var items = new List<SelectListItem>();
            allPositions.ToList().ForEach(position => items.Add(new SelectListItem { Text = position.Name, Value = position.ID.ToString() }));

            return items;
        }

        public static async Task<Position> GetPlayerPosition(Player player, IPositionService positionService)
        {
            var allPositions = await positionService.GetAllPositions();
            var playerPosition = allPositions.FirstOrDefault(p => p.ID == player.PositionID);

            return playerPosition;
        }

        public static async Task<TeamListResponse> GetPlayerTeam(Player player, ITeamService teamService)
        {
            var allTeams = await teamService.GetAllTeams();
            var playerTeam = allTeams.FirstOrDefault(t => t.ID == player.TeamID);

            return playerTeam;
        }
    }
}
