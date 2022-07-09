using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class PlayersStats
    {
        public int PlayerID { get; set; }
        public Player Player { get; set; }
        public int StatsID { get; set; }
        public Stats Stats { get; set; }

        public string Value { get; set; }
    }
}
