using nbaDemo.DTOs.Requests.TeamRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Abstracts
{
    public interface ITeamService
    {
        Task<ICollection<TeamListResponse>> GetAllTeams();
        Task<Team> GetTeamById(int id);
        Task<int> AddTeam(TeamAddRequest request);
        Task<int> EditTeam(TeamEditRequest request);
        Task DeleteTeam(int id);
        Task<bool> IsExist(int id);
    }
}
