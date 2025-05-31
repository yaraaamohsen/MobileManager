namespace Domain.Exceptions
{
    public class ValidationException(string message = "Error Message Description") : Exception(message)
    {
    }
}
