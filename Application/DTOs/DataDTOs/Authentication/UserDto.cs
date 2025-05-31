using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DataDTOs.Authentication
{
    public class UserDto
    {
        [Required(ErrorMessage = "Client code is required")]
        [RegularExpression(@"^\d{3,10}$")]
        public string ClientCode { get; set; } = default!;
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = default!;
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;
    }
}
