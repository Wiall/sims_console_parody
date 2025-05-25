namespace Application.Validation;

public class OutOfRangeException : Exception
{
    public OutOfRangeException()
    {
    }

    public OutOfRangeException(string message)
        : base($"{message} out of legal range!")
    {
    }

    public OutOfRangeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}