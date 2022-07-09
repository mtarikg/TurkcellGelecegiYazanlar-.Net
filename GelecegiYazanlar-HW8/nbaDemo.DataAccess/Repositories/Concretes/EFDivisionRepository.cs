using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Concretes
{
    public class EFDivisionRepository : EFGenericRepository<Division>, IDivisionRepository
    {
        public EFDivisionRepository(NbaDbContext dbContext) : base(dbContext) { }

        public async Task<Division> GetDivisionByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(division => division.Name.Contains(name));
        }
    }
}
