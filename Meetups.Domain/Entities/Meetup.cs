namespace Meetups.Domain.Entities
{
    public class Meetup : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}