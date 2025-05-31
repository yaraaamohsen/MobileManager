using Application.DTOs;
using Application.DTOs.DataDTOs.Authentication;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public BaseResponse<TokenDataDto> Login(UserDto user);
    }
}
