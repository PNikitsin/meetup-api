using Meetups.Application.DTOs;
using Meetups.Application.Services.Interfaces;
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
        public async Task<IActionResult> GetMeetups(CancellationToken cancellationToken)
        {
            var meetups = await _meetupService.GetMeetupsAsync(cancellationToken);

            return Ok(meetups);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMeetup(Guid id, CancellationToken cancellationToken)
        {
            var meetup = await _meetupService.GetMeetupAsync(id, cancellationToken);

            return Ok(meetup);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeetup(InputMeetupDto inputMeetupDto, CancellationToken cancellationToken)
        {
            var meetup = await _meetupService.CreateMeetupAsync(inputMeetupDto, cancellationToken);

            var actionName = nameof(GetMeetup);
            var routeValues = new { id = meetup.Id };

            return CreatedAtAction(actionName, routeValues, meetup);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeetup(Guid id, InputMeetupDto inputMeetupDto, CancellationToken cancellationToken)
        {
            var meetup = await _meetupService.UpdateMeetupAsync(id, inputMeetupDto, cancellationToken);

            return Ok(meetup);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetup(Guid id, CancellationToken cancellationToken)
        {
            await _meetupService.DeleteMeetupAsync(id, cancellationToken);

            return NoContent();
        }
    }
}