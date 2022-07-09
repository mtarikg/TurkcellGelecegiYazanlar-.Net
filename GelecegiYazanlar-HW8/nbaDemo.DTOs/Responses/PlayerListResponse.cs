namespace nbaDemo.DTOs.Responses
{
    public class PlayerListResponse : BaseListResponse
    {
        public string FullName { get; set; }
        public string Country { get; set; }
        public string LastAttended { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Age { get; set; }
        public string JerseyNumber { get; set; }
        public string Experience { get; set; }
        public string ProfileImage { get; set; }
        public int? TeamID { get; set; }
        public int PositionID { get; set; }
    }
}
