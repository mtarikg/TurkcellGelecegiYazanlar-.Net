using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class Stats
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<PlayersStats> Players { get; set; }
        public ICollection<TeamsStats> Teams { get; set; }
    }
}
