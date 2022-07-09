using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class TeamsStats
    {
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public int StatsID { get; set; }
        public Stats Stats { get; set; }

        public string Value { get; set; }
    }
}
