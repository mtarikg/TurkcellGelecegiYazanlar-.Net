using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Concretes
{
    public class EFConferenceRepository : EFGenericRepository<Conference>, IConferenceRepository
    {
        public EFConferenceRepository(NbaDbContext dbContext) : base(dbContext) { }

        public async Task<Conference> GetConferenceByName(string name)
        {
            return await dbSet.FirstOrDefaultAsync(conference => conference.Name.Contains(name));
        }
    }
}
