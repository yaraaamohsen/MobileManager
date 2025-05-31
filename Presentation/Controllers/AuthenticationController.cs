using Application.DTOs.DataDTOs.Authentication;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var result = _authService.Login(userDto);
            return Ok(result);
        }

        /*
            {
              "clientCode": "Client01",
              "username": "User01",
              "password": "P@ssW0rd01"
            }
         */
    }
}
