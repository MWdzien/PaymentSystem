namespace PaymentSystem.Exceptions;

public class InvalidTimespanException : Exception
{
    public InvalidTimespanException()
    {
    }

    public InvalidTimespanException(string? message) : base(message)
    {
    }
}