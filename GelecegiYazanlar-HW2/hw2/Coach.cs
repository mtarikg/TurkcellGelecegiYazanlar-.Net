using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    abstract class Coach
    {
        public int CoachID { get; set; }
        public string Name { get; set; }
        public List<Player> PlayersList { get; set; }
    }
}
