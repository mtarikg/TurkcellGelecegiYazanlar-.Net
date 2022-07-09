using AutoMapper;
using nbaDemo.Business.Abstracts;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.DTOs.Requests.TeamRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Concretes
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IMapper mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            this.teamRepository = teamRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddTeam(TeamAddRequest request)
        {
            var team = mapper.Map<Team>(request);
            var result = await teamRepository.Add(team);

            return result;
        }

        public async Task DeleteTeam(int id)
        {
            await teamRepository.Delete(id);
        }

        public async Task<ICollection<TeamListResponse>> GetAllTeams()
        {
            var teams = await teamRepository.GetAllEntities();
            var teamsListResponse = mapper.Map<List<TeamListResponse>>(teams);

            return teamsListResponse;
        }

        public async Task<Team> GetTeamById(int id)
        {
            Team team = await teamRepository.GetEntityById(id);

            return team;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await teamRepository.IsExist(id);

            return result;
        }

        public async Task<int> EditTeam(TeamEditRequest request)
        {
            var team = await GetTeamById(request.ID);
            var editedTeam = mapper.Map<Team>(request);
            editedTeam.FoundationYear = team.FoundationYear;
            team = editedTeam;
            var result = await teamRepository.Update(team);

            return result;
        }
    }
}
