using nbaDemo.Entities.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.DataAccess
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllEntities();
        Task<T> GetEntityById(int id);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task Delete(int id);
        Task<bool> IsExist(int id);
    }
}
