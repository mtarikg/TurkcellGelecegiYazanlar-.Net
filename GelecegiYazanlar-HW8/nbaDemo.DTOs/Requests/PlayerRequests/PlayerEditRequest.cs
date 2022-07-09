using System.ComponentModel.DataAnnotations;

namespace nbaDemo.DTOs.Requests.PlayerRequests
{
    public class PlayerEditRequest
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The name of a player can not be empty.")]
        public string FullName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [Display(Name = "Jersey Number")]
        public string JerseyNumber { get; set; }
        public string Experience { get; set; }
        public string Age { get; set; }
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }
        public int? TeamID { get; set; }
        public int PositionID { get; set; }
    }
}
