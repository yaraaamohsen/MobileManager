using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TokenService(IConfiguration _configuration) : ITokenService
    {
        public string GenerateToken(string username)
        {
            var Claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };
            var secretKey = _configuration["jwtOptions:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["jwtOptions:Issuer"],
                audience: _configuration["jwtOptions:Audience"],
                claims: Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
