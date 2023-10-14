namespace Meetups.Domain.Entities
{
    public class Meetup : Entity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
        public string Organizer { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}