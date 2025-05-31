namespace Domain.Exceptions
{
    public class UnauthorizedException(string message = "Not Authorized") : Exception(message)
    {
    }
}
