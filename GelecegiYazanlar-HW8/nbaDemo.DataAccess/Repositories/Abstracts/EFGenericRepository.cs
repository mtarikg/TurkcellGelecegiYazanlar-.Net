using Microsoft.EntityFrameworkCore;
using nbaDemo.DataAccess.Data;
using nbaDemo.Entities.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public abstract class EFGenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly NbaDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public EFGenericRepository(NbaDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity.ID;
        }

        public async Task Delete(int id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(e => e.ID == id);
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllEntities()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await dbSet.AnyAsync(entity => entity.ID == id);
        }

        public async Task<int> Update(T entity)
        {
            dbSet.Update(entity);

            return await dbContext.SaveChangesAsync();
        }
    }
}
