using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Authentication
{
    public class UserDto
    {
        [Required]
        public string ClientCode { get; set; } = default!;
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
