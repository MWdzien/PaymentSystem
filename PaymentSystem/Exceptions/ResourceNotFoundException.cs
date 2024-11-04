namespace PaymentSystem.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException()
    {
    }
    
    public ResourceNotFoundException(string resourceName, int resourceId) : base( $"{resourceName} with ID: {resourceId} does not exist")
    {
    }
    
    public ResourceNotFoundException(string resourceName, string resource) : base( $"{resourceName}: {resource} does not exist")
    {
    }

    public ResourceNotFoundException(string? message) : base(message)
    {
    }
}