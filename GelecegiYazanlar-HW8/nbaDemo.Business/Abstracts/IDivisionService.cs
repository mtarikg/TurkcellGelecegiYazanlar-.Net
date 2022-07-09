using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Abstracts
{
    public interface IDivisionService
    {
        Task<ICollection<Division>> GetAllDivisions();
        Task<Division> GetDivisionById(int id);
        Task<bool> IsExist(int id);
    }
}
