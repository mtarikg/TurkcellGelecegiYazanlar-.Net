using System.ComponentModel.DataAnnotations;

namespace nbaDemo.DTOs.Requests.TeamRequests
{
    public class TeamEditRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        [Display(Name = "Current Owner")]
        public string CurrentOwner { get; set; }
        [Display(Name = "Head Coach")]
        public string HeadCoach { get; set; }
        public string Arena { get; set; }
        public int DivisionID { get; set; }
        public int ConferenceID { get; set; }
    }
}
