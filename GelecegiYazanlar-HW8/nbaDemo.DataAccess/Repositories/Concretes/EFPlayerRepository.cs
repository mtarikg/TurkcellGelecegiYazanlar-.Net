using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Concretes
{
    public class EFPlayerRepository : EFGenericRepository<Player>, IPlayerRepository
    {
        public EFPlayerRepository(NbaDbContext dbContext) : base(dbContext) { }

        public async Task<Player> GetPlayerByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(player => player.FullName.Contains(name));
        }
    }
}
