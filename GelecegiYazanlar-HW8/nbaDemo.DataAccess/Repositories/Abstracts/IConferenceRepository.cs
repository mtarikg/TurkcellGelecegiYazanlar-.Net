using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public interface IConferenceRepository : IRepository<Conference>
    {
        Task<Conference> GetConferenceByName(string name);
    }
}
