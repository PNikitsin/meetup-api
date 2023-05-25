using Meetups.Web.Application.DTOs;
using Meetups.Web.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetups.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService _meetupService;

        public MeetupController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        [HttpGet]
        [Route("get-meetups")]
        public async Task<IActionResult> GetMeetupsAsync()
        {
            var meetups = await _meetupService.GetMeetupsAsync();
            return Ok(meetups);
        }

        [HttpGet]
        [Route("get-meetup/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var meetup = await _meetupService.GetMeetupAsync(id);
            return Ok(meetup);
        }

        [HttpPost]
        [Route("create-meetup")]
        public async Task<IActionResult> CreateMeetupAsync(CreateMeetupDto createMeetupDto)
        {
            await _meetupService.CreateMeetupAsync(createMeetupDto);
            return Created("api/meetup/id", createMeetupDto);
        }

        [HttpPut]
        [Route("update-meetup")]
        public async Task<IActionResult> UpdateMeetupAsync(UpdateMeetupDto updateMeetupDto)
        {
            await _meetupService.UpdateMeetupAsync(updateMeetupDto);
            return Ok(updateMeetupDto);
        }

        [HttpDelete]
        [Route("delete-meetup/{id}")]
        public async Task<IActionResult> DeleteMeetupAsync(int id)
        {
            await _meetupService.DeleteMeetupAsync(id);
            return NoContent();
        }
    }
}