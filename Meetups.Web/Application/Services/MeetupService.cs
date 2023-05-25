using AutoMapper;
using Meetups.Domain.Interfaces;
using Meetups.Domain.Entities;
using Meetups.Web.Application.DTOs;
using Meetups.Web.Application.Exceptions;

namespace Meetups.Web.Application.Services
{
    public class MeetupService : IMeetupService
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public MeetupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Meetup>> GetMeetupsAsync()
        {
            return await _unitOfWork.Meetups.GetAllAsync();
        }

        public async Task<Meetup> GetMeetupAsync(int id)
        {
            var meetup = await _unitOfWork.Meetups.GetByIdAsync(id);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found");
            }

            return meetup;
        }

        public async Task CreateMeetupAsync(CreateMeetupDto createMeetupDto)
        {
            var meetup = _mapper.Map<CreateMeetupDto, Meetup>(createMeetupDto);
            
            await _unitOfWork.Meetups.AddAsync(meetup);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateMeetupAsync(UpdateMeetupDto updateMeetupDto)
        {
            var meetup = await _unitOfWork.Meetups.GetByIdAsync(updateMeetupDto.Id);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found");
            }

            meetup.Name = updateMeetupDto.Name;
            meetup.Description = updateMeetupDto.Description;
            meetup.Speaker = updateMeetupDto.Speaker;
            meetup.Location = updateMeetupDto.Location;
            meetup.Time = updateMeetupDto.Time;

            _unitOfWork.Meetups.Update(meetup);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteMeetupAsync(int id)
        {
            var meetup = await _unitOfWork.Meetups.GetByIdAsync(id);

            if (meetup == null)
            {
                throw new NotFoundException("Meetup not found");
            }

            _unitOfWork.Meetups.Remove(meetup);
            await _unitOfWork.CommitAsync();
        }
    }
}