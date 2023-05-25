using Meetups.Domain.Entities;
using Meetups.Web.Application.DTOs;

namespace Meetups.Web.Application.Services
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