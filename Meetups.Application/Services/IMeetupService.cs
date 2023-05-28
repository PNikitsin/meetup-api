using Meetups.Application.DTOs;
using Meetups.Domain.Entities;

namespace Meetups.Application.Services
{
    public interface IMeetupService
    {
        Task<IEnumerable<Meetup>> GetMeetupsAsync();
        Task<Meetup> GetMeetupAsync(int id);
        Task CreateMeetupAsync(CreateMeetupDto createMeetupDto);
        Task UpdateMeetupAsync(UpdateMeetupDto updateMeetupDto);
        Task DeleteMeetupAsync(int id);
    }
}