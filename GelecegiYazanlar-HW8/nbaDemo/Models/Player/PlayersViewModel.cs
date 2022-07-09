using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;

namespace nbaDemo.Web.Models
{
    public class PlayersViewModel
    {
        public IDictionary<Position, IList<PlayerListResponse>> PositionPlayers { get; set; }
    }
}
