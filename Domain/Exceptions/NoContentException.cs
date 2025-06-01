namespace Domain.Exceptions
{
    public class NoContentException(string message = default!) : Exception(message)
    {
    }
}
