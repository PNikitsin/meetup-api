namespace Meetups.Application.DTOs
{
    public class OutputMeetupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
        public string Organizer { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}