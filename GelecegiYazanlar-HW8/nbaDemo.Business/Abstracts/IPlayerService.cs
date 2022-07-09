using nbaDemo.DTOs.Requests.PlayerRequests;
using nbaDemo.DTOs.Responses;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Abstracts
{
    public interface IPlayerService
    {
        Task<ICollection<PlayerListResponse>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<int> AddPlayer(PlayerAddRequest player);
        Task<int> EditPlayer(PlayerEditRequest request);
        Task DeletePlayer(int id);
        Task<bool> IsExist(int id);
    }
}
