namespace nbaDemo.DTOs.Responses
{
    public class TeamListResponse : BaseListResponse
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public int ConferenceID { get; set; }
        public int DivisionID { get; set; }
    }
}
