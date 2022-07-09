using AutoMapper;
using nbaDemo.Business.Abstracts;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.DTOs.Requests.PlayerRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Concretes
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IMapper mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            this.playerRepository = playerRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddPlayer(PlayerAddRequest request)
        {
            var player = mapper.Map<Player>(request);
            var result = await playerRepository.Add(player);

            return result;
        }

        public async Task DeletePlayer(int id)
        {
            await playerRepository.Delete(id);
        }

        public async Task<ICollection<PlayerListResponse>> GetAllPlayers()
        {
            var players = await playerRepository.GetAllEntities();
            var playerListResponse = mapper.Map<List<PlayerListResponse>>(players);

            return playerListResponse;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            Player player = await playerRepository.GetEntityById(id);

            return player;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await playerRepository.IsExist(id);

            return result;
        }

        public async Task<int> EditPlayer(PlayerEditRequest request)
        {
            var player = await GetPlayerById(request.ID);
            var editedPlayer = mapper.Map<Player>(request);
            editedPlayer.Country = player.Country;
            editedPlayer.LastAttended = player.LastAttended;
            editedPlayer.DraftInfo = player.DraftInfo;
            editedPlayer.DateOfBirth = player.DateOfBirth;
            player = editedPlayer;
            var result = await playerRepository.Update(player);

            return result;
        }
    }
}
