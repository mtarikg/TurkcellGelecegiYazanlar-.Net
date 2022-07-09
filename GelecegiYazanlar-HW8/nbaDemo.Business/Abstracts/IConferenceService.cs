using nbaDemo.DTOs.Requests;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Abstracts
{
    public interface IConferenceService
    {
        Task<ICollection<Conference>> GetAllConferences();
        Task<Conference> GetConferenceById(int id);
        Task<int> EditConference(ConferenceEditRequest request);
        Task<bool> IsExist(int id);
    }
}
