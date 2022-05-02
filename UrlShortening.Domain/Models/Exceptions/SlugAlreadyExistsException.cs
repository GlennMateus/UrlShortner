namespace Domain.Models.Errors;

public class SlugAlreadyExistsException : Exception
{
    public SlugAlreadyExistsException()
    {
        
    }

    public SlugAlreadyExistsException(string? message) : base(message)
    {
        
    }

    public SlugAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
        
    }
}