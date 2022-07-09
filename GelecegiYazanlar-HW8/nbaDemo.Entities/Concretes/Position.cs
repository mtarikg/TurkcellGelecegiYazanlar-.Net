using nbaDemo.Entities.Abstracts;
using System;
using System.Collections.Generic;

namespace nbaDemo.Entities
{
    public class Position : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Player> Players { get; set; }
    }
}
