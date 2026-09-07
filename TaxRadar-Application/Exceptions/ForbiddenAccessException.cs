namespace TaxRadar_Application.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException(string message) : base(message)
    {
    }
}
