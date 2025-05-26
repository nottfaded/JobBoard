namespace JobBoard.Application.Exception;

public class AccountNotFoundException : System.Exception
{
    public AccountNotFoundException(string id) : base($"Account with {id} Id does not exist!")
    {
    }
    public AccountNotFoundException(string id, System.Exception innerException) 
        : base($"Account with {id} Id does not exist!", innerException)
    {
    }
}