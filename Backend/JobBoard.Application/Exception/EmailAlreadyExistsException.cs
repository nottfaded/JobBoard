namespace JobBoard.Application.Exception;

public class EmailAlreadyExistsException : System.Exception
{
    public EmailAlreadyExistsException(string email)
        : base($"An account with the email '{email}' already exists.")
    {
    }
    public EmailAlreadyExistsException(string email, System.Exception innerException)
        : base($"An account with the email '{email}' already exists.", innerException)
    {
    }
}