using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class Player
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public double OffensiveRating { get; set; } // The amount of points produced by a player per 100 possessions.
        public double DefensiveRating { get; set; } // The amount of points allowed by a player per 100 possessions.
        public double ImpactEstimate { get; set; } // A player's all contributions in a basketball game.
        public string WeakerSide { get; set; }

    }
}
