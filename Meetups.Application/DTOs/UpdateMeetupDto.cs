using System.ComponentModel.DataAnnotations;

namespace Meetups.Application.DTOs
{
    public class UpdateMeetupDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(520)]
        public string Description { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        public string Speaker { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        public string Location { get; set; } = null!;
        public DateTime Time { get; set; }
    }
}