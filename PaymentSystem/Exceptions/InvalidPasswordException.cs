namespace PaymentSystem.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Wrong password")
    {
    }

    public InvalidPasswordException(string? message) : base(message)
    {
    }
}