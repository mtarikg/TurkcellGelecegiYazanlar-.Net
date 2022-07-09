using AutoMapper;
using nbaDemo.Business.Abstracts;
using nbaDemo.DataAccess.Repositories.Abstracts;
using nbaDemo.DTOs.Requests;
using nbaDemo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nbaDemo.Business.Concretes
{
    public class ConferenceService : IConferenceService
    {
        private readonly IConferenceRepository conferenceRepository;
        private readonly IMapper mapper;

        public ConferenceService(IConferenceRepository conferenceRepository, IMapper mapper)
        {
            this.conferenceRepository = conferenceRepository;
            this.mapper = mapper;
        }

        public async Task<ICollection<Conference>> GetAllConferences()
        {
            var allConferences = await conferenceRepository.GetAllEntities();
            return allConferences;
        }

        public async Task<Conference> GetConferenceById(int id)
        {
            Conference conference = await conferenceRepository.GetEntityById(id);

            return conference;
        }

        public async Task<bool> IsExist(int id)
        {
            var result = await conferenceRepository.IsExist(id);
            return result;
        }

        public async Task<int> EditConference(ConferenceEditRequest request)
        {
            var conference = await GetConferenceById(request.ID);
            var editedConference = mapper.Map<Conference>(request);
            editedConference.Name = conference.Name;
            conference = editedConference;
            var result = await conferenceRepository.Update(conference);

            return result;
        }
    }
}
