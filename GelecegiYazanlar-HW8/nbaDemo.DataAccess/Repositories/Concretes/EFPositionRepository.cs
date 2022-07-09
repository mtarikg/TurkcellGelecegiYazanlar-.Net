using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Concretes
{
    public class EFPositionRepository : EFGenericRepository<Position>, IPositionRepository
    {
        public EFPositionRepository(NbaDbContext dbContext) : base(dbContext) { }

        public async Task<Position> GetPositionByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(position => position.Name.Contains(name));
        }
    }
}
