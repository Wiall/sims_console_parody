namespace Application.Validation;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message)
        : base($"{message} not found!")
    {
    }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}