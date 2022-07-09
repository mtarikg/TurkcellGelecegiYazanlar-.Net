using Microsoft.AspNetCore.Mvc.Rendering;
using nbaDemo.Business.Abstracts;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nbaDemo.Web.Controllers.ControllersHelperMethods
{
    public static class TeamsControllerHelperMethods
    {
        public static IDictionary<Division, IList<TeamListResponse>> GetDivisionTeams(ICollection<Division> allDivisions, ICollection<TeamListResponse> allTeams)
        {
            var divisionsTeamsDictionary = new Dictionary<Division, IList<TeamListResponse>>();

            foreach (var division in allDivisions)
            {
                divisionsTeamsDictionary.Add(division, null);
                var divisionTeamsList = new List<TeamListResponse>();

                foreach (var team in allTeams)
                {
                    if (division.ID == team.DivisionID)
                    {
                        divisionTeamsList.Add(team);

                        if (!divisionsTeamsDictionary.ContainsKey(division))
                        {
                            divisionsTeamsDictionary.Add(division, divisionTeamsList);
                            break;
                        }

                        divisionsTeamsDictionary[division] = divisionTeamsList;
                    }
                }
            }

            return divisionsTeamsDictionary;
        }

        public async static Task<List<SelectListItem>> GetConferencesForDropDownList(IConferenceService conferenceService)
        {
            var allConferences = await conferenceService.GetAllConferences();
            var items = new List<SelectListItem>();
            allConferences.ToList().ForEach(conference => items.Add(new SelectListItem { Text = conference.Name, Value = conference.ID.ToString() }));

            return items;
        }

        public async static Task<List<SelectListItem>> GetDivisionsForDropDownList(IDivisionService divisionService)
        {
            var allDivisions = await divisionService.GetAllDivisions();
            var items = new List<SelectListItem>();
            allDivisions.ToList().ForEach(division => items.Add(new SelectListItem { Text = division.Name, Value = division.ID.ToString() }));

            return items;
        }
    }
}
