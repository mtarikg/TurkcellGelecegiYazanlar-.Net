using nbaDemo.Business.Abstracts;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Concretes
{
    public class DivisionService : IDivisionService
    {
        private readonly IDivisionRepository divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }

        public async Task<ICollection<Division>> GetAllDivisions()
        {
            var allDivisions = await divisionRepository.GetAllEntities();
            return allDivisions;
        }

        public async Task<Division> GetDivisionById(int id)
        {
            Division division = await divisionRepository.GetEntityById(id);

            return division;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await divisionRepository.IsExist(id);
            return result;
        }
    }
}
