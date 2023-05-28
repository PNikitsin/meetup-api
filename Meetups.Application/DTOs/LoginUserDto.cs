using System.ComponentModel.DataAnnotations;

namespace Meetups.Application.DTOs
{
    public class LoginUserDto
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = null!;
        [Required]
        [MaxLength(60)]
        public string Password { get; set; } = null!;
    }
}