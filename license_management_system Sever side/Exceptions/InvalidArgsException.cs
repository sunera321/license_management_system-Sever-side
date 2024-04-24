namespace license_mngt_system_backend.Exceptions;

public class InvalidArgsException : Exception
{
    public InvalidArgsException(string message) : base(message)
    {
    }
}