using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Models
{
    class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string LastAttended { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string JerseyNumber { get; set; }
        public string Experience { get; set; }
        public string Age { get; set; }
        public string DraftInfo { get; set; }
        public string DateOfBirth { get; set; }

        // Navigation Properties
        public Team Team { get; set; }
        public int? TeamID { get; set; }
        public Position Position { get; set; }
        public int PositionID { get; set; }

        public ICollection<PlayersStats> Stats { get; set; }
    }
}
