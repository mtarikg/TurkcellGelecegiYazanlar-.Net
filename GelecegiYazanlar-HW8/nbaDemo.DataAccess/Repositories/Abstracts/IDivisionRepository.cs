using nbaDemo.Entities;
using System.Threading.Tasks;
namespace nbaDemo.DataAccess.Repositories.Abstracts
{
    public interface IDivisionRepository : IRepository<Division>
    {
        Task<Division> GetDivisionByName(string name);
    }
}
