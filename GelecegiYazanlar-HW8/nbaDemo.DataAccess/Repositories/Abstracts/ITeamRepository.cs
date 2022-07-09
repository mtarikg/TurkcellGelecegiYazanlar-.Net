using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetTeamByName(string name);
    }
}
