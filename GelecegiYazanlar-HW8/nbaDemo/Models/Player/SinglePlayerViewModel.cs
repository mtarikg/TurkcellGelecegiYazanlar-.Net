using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;

namespace nbaDemo.Web.Models
{
    public class SinglePlayerViewModel
    {
        public Player Player { get; set; }
        public TeamListResponse Team { get; set; }
        public Position Position { get; set; }
    }
}
