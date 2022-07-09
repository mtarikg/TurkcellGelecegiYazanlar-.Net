using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class Conference
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public List<Team> Teams { get; set; }
    }
}
