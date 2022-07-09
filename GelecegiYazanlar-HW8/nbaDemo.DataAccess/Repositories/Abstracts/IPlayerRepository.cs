using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> GetPlayerByName(string name);
    }
}
