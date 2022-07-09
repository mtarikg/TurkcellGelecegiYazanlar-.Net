using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Concretes
{
    public class EFTeamRepository : EFGenericRepository<Team>, ITeamRepository
    {
        public EFTeamRepository(NbaDbContext dbContext) : base(dbContext) { }

        public async Task<Team> GetTeamByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(team => team.Name.Contains(name));
        }
    }
}
