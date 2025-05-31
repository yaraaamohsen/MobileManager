using Application.DTOs;
using Application.DTOs.DataDTOs.Authentication;
using Application.Interfaces;

namespace Application.Services
{
    public class AuthService(ITokenService _tokenService) : IAuthService
    {
        public BaseResponse<TokenDataDto> Login(UserDto user)
        {
            if (user.ClientCode != "Client01" || user.UserName != "User01" || user.Password != "P@ssW0rd01")
            {
                return new BaseResponse<TokenDataDto>("InvalidCredentials");
            }

            var token = _tokenService.GenerateToken(user.UserName);
            var Data = new TokenDataDto
            {
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiresIn = DateTime.UtcNow.AddDays(1)
            };

            return new BaseResponse<TokenDataDto>(Data);
        }
    }
}
