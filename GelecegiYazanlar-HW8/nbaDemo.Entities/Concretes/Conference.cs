using nbaDemo.Entities.Abstracts;
using System;
using System.Collections.Generic;

namespace nbaDemo.Entities
{
    public class Conference : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public List<Team> Teams { get; set; }

    }
}
