using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;

namespace nbaDemo.Web.Models
{
    public class TeamsViewModel
    {
        public IDictionary<Division, IList<TeamListResponse>> DivisionTeams { get; set; }
    }
}
