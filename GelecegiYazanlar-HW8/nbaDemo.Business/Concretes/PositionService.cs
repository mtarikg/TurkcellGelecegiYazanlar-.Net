using nbaDemo.Business.Abstracts;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Concretes
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        public async Task<ICollection<Position>> GetAllPositions()
        {
            var positions = await positionRepository.GetAllEntities();

            return positions;
        }

        public async Task<Position> GetPositionById(int id)
        {
            Position position = await positionRepository.GetEntityById(id);

            return position;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await positionRepository.IsExist(id);

            return result;
        }
    }
}
