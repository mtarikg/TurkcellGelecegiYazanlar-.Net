using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<Position> GetPositionByName(string name);
    }
}
