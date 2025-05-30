namespace Application.DTOs.DataDTOs.Authentication
{
    public class TokenDataDto
    {
        public string Token { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
