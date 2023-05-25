namespace Meetups.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}