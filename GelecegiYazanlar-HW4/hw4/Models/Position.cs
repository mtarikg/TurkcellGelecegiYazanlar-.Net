using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
