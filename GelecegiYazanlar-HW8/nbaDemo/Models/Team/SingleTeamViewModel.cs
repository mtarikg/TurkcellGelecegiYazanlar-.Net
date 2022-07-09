using nbaDemo.Entities;

namespace nbaDemo.Web.Models
{
    public class SingleTeamViewModel
    {
        public Team Team { get; set; }
        public Conference Conference { get; set; }
        public Division Division { get; set; }
    }
}
