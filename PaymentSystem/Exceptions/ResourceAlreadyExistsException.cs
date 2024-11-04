namespace PaymentSystem.Exceptions;

public class ResourceAlreadyExistsException : Exception
{
    public ResourceAlreadyExistsException()
    {
    }

    public ResourceAlreadyExistsException(string resourceName, int resourceId) : base( $"{resourceName} with ID: {resourceId} already exists")
    {
    }
    
    public ResourceAlreadyExistsException(string resourceName, string resource) : base( $"{resourceName}: {resource} already exists")
    {
    }

    public ResourceAlreadyExistsException(string? message) : base(message)
    {
    }
}