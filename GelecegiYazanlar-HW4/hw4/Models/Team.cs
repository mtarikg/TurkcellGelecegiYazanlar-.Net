using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string FoundationYear { get; set; }
        public string CurrentOwner { get; set; }
        public string HeadCoach { get; set; }
        public string Arena { get; set; }

        // Navigation Properties
        public Division Division { get; set; }
        public int DivisionID { get; set; }
        public Conference Conference { get; set; }
        public int ConferenceID { get; set; }

        public List<Player> Players { get; set; }
        public ICollection<TeamsStats> Stats { get; set; }
    }
}
