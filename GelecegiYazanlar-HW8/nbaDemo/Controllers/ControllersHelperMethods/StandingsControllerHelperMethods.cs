using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;

namespace nbaDemo.Web.Controllers.ControllersHelperMethods
{
    public static class StandingsControllerHelperMethods
    {
        public static IDictionary<Conference, IList<TeamListResponse>> GetConferenceTeams(ICollection<Conference> allConferences, ICollection<TeamListResponse> allTeams)
        {
            var conferenceTeamsDictionary = new Dictionary<Conference, IList<TeamListResponse>>();

            foreach (var conference in allConferences)
            {
                var conferenceTeamsList = new List<TeamListResponse>();

                foreach (var team in allTeams)
                {
                    if (conference.ID == team.ConferenceID)
                    {
                        conferenceTeamsList.Add(team);

                        if (conferenceTeamsDictionary.ContainsKey(conference))
                        {
                            conferenceTeamsDictionary[conference] = conferenceTeamsList;
                        }
                        else
                        {
                            conferenceTeamsDictionary.Add(conference, conferenceTeamsList);
                        }
                    }
                }
            }

            return conferenceTeamsDictionary;
        }
    }
}
