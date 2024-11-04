namespace PaymentSystem.Exceptions;

public class ClientDeletedException : Exception
{
    public ClientDeletedException()
    {
    }

    public ClientDeletedException(int clientId) : base($"Client with ID: {clientId} has been deleted")
    {
    }

    public ClientDeletedException(string? message) : base(message)
    {
    }
}