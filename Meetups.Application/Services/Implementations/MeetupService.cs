using AutoMapper;
using Meetups.Application.DTOs;
using Meetups.Application.Exceptions;
using Meetups.Application.Services.Interfaces;
using Meetups.Domain.Entities;
using Meetups.Domain.Interfaces;

namespace Meetups.Application.Services.Implementations
{
    public class MeetupService : IMeetupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OutputMeetupDto>> GetMeetupsAsync(CancellationToken cancellationToken)
        {
            var meetups = await _unitOfWork.Meetups.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<OutputMeetupDto>>(meetups);
        }

        public async Task<OutputMeetupDto> GetMeetupAsync(Guid id, CancellationToken cancellationToken)
        {
            var meetup = await _unitOfWork.Meetups.GetAsync(meetup => meetup.Id == id, cancellationToken);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found.");
            }

            return _mapper.Map<OutputMeetupDto>(meetup);
        }

        public async Task<OutputMeetupDto> CreateMeetupAsync(InputMeetupDto inputMeetupDto, CancellationToken cancellationToken)
        {
            var meetup = _mapper.Map<Meetup>(inputMeetupDto);

            await _unitOfWork.Meetups.AddAsync(meetup, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<OutputMeetupDto>(meetup);
        }

        public async Task<OutputMeetupDto> UpdateMeetupAsync(Guid id, InputMeetupDto inputMeetupDto, CancellationToken cancellationToken)
        {
            var meetup = await _unitOfWork.Meetups.GetAsync(meetup => meetup.Id == id, cancellationToken);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found.");
            }

            meetup.Name = inputMeetupDto.Name;
            meetup.DateAndTime = inputMeetupDto.DateAndTime;
            meetup.Organizer = inputMeetupDto.Organizer;
            meetup.Address = inputMeetupDto.Address;
            meetup.Description = inputMeetupDto.Description;

            _unitOfWork.Meetups.Update(meetup);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<OutputMeetupDto>(meetup);
        }

        public async Task DeleteMeetupAsync(Guid id, CancellationToken cancellationToken)
        {
            var meetup = await _unitOfWork.Meetups.GetAsync(meetup => meetup.Id == id, cancellationToken);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found.");
            }

            _unitOfWork.Meetups.Remove(meetup);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}