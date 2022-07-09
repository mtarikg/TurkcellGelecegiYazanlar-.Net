using nbaDemo.Entities.Abstracts;
using System;
using System.Collections.Generic;

namespace nbaDemo.Entities
{
    public class Division : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Team> Teams { get; set; }
    }
}
