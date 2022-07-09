using nbaDemo.Entities.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace nbaDemo.Entities
{
    public class Player : IEntity
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The name of a player can not be empty.")]
        public string FullName { get; set; }
        public string Country { get; set; }
        [Display(Name = "Last Attended")]
        public string LastAttended { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [Display(Name = "Jersey Number")]
        public string JerseyNumber { get; set; }
        public string Experience { get; set; }
        public string Age { get; set; }
        [Display(Name = "Draft Info")]
        public string DraftInfo { get; set; }
        [Display(Name = "Birthdate")]
        public string DateOfBirth { get; set; }
        public string ProfileImage { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public Team Team { get; set; }
        public int? TeamID { get; set; }
        public Position Position { get; set; }
        public int PositionID { get; set; }
    }
}
