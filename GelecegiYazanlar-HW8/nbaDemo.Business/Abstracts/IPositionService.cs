using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Abstracts
{
    public interface IPositionService
    {
        Task<ICollection<Position>> GetAllPositions();
        Task<Position> GetPositionById(int id);
        Task<bool> IsExist(int id);
    }
}
