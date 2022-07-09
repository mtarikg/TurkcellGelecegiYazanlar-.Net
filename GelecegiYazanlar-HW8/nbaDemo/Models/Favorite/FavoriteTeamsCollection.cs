using nbaDemo.DTOs.Responses;
using System;
using System.Collections.Generic;

namespace nbaDemo.Web.Models
{
    public class FavoriteTeam
    {
        public TeamListResponse Team { get; set; }
    }

    public class FavoriteTeamsCollection
    {
        public List<FavoriteTeam> FavoriteTeams { get; set; } = new List<FavoriteTeam>();

        public bool FindPlayer(int id)
        {
            var teamFound = FavoriteTeams.Find(t => t.Team.ID == id);

            if (teamFound != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPlayer(FavoriteTeam team)
        {
            var result = FindPlayer(team.Team.ID);

            if (!result)
            {
                FavoriteTeams.Add(team);
            }
            else
            {
                Console.WriteLine("Error for adding team");
            }
        }

        public void Delete(int id) => FavoriteTeams.RemoveAll(ft => ft.Team.ID == id);
    }
}
