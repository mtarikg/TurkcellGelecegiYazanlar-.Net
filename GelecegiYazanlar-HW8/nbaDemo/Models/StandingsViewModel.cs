using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;

namespace nbaDemo.Web.Models
{
    public class StandingsViewModel
    {
        public IDictionary<Conference, IList<TeamListResponse>> ConferenceTeams { get; set; }
    }
}
