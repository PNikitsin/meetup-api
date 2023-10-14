using Meetups.Application.DTOs;

namespace Meetups.Application.Services.Interfaces
{
    public interface IMeetupService
    {
        Task<IEnumerable<OutputMeetupDto>> GetMeetupsAsync(CancellationToken cancellationToken);
        Task<OutputMeetupDto> GetMeetupAsync(Guid id, CancellationToken cancellationToken);
        Task<OutputMeetupDto> CreateMeetupAsync(InputMeetupDto inputMeetupDto, CancellationToken cancellationToken);
        Task<OutputMeetupDto> UpdateMeetupAsync(Guid id, InputMeetupDto inputMeetupDto, CancellationToken cancellationToken);
        Task DeleteMeetupAsync(Guid id, CancellationToken cancellationToken);
    }
}