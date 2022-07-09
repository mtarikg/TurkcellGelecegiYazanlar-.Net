using System.ComponentModel.DataAnnotations;

namespace nbaDemo.DTOs.Requests.PlayerRequests
{
    public class PlayerAddRequest
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The name of a player can not be empty.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "The country of a player can not be empty.")]
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
        [Required(ErrorMessage = "The birthdate of a player can not be empty.")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }
        public int? TeamID { get; set; }
        public int PositionID { get; set; }
    }
}
