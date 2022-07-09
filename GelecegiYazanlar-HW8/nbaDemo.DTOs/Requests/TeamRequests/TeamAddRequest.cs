using System.ComponentModel.DataAnnotations;

namespace nbaDemo.DTOs.Requests.TeamRequests
{
    public class TeamAddRequest
    {
        [Required(ErrorMessage = "The name of a team can not be empty.")]
        public string Name { get; set; }
        public string Logo { get; set; }
        [Display(Name = "Foundation Year")]
        [Required(ErrorMessage = "The foundation year of a team can not be empty.")]
        public string FoundationYear { get; set; }
        [Display(Name = "Current Owner")]
        [Required(ErrorMessage = "The current owner of a team can not be empty.")]
        public string CurrentOwner { get; set; }
        [Display(Name = "Head Coach")]
        public string HeadCoach { get; set; }
        public string Arena { get; set; }
        public int DivisionID { get; set; }
        public int ConferenceID { get; set; }
    }
}
