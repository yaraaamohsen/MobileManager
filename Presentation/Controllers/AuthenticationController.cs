using Application.DTOs.DataDTOs.Authentication;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("NT/[controller]")]
    public class AuthenticationController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("GenerateToken")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var result = _authService.Login(userDto);
            return Ok(result);
        }

        /*
            {
              "clientCode": "0123",
              "username": "User01",
              "password": "P@ssW0rd01"
            }
         */
    }
}
