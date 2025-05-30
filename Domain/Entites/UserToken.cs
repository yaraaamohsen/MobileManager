namespace Domain.Entites
{
    public class UserToken
    {
        public string ClientCode { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
