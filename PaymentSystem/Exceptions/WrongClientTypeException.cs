namespace PaymentSystem.Exceptions;

public class WrongClientTypeException : Exception
{
    public WrongClientTypeException()
    {
    }

    public WrongClientTypeException(string? message) : base(message)
    {
    }
}