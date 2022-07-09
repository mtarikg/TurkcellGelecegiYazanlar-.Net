using AutoMapper;
using nbaDemo.DTOs.Requests;
using nbaDemo.DTOs.Requests.PlayerRequests;
using nbaDemo.DTOs.Requests.TeamRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;

namespace nbaDemo.Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Player, PlayerListResponse>();
            CreateMap<PlayerAddRequest, Player>();
            CreateMap<PlayerEditRequest, Player>();
            CreateMap<PlayerListResponse, PlayerEditRequest>();
            CreateMap<Conference, ConferenceEditRequest>();
            CreateMap<ConferenceEditRequest, Conference>();
            CreateMap<Team, TeamListResponse>();
            CreateMap<TeamAddRequest, Team>();
            CreateMap<TeamEditRequest, Team>();
            CreateMap<Team, TeamEditRequest>();
        }
    }
}
