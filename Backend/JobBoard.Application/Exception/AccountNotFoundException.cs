namespace JobBoard.Application.Exception;

public class AccountNotFoundException : System.Exception
{
    public AccountNotFoundException(object id) : base($"Account with {id} Id does not exist!")
    {
    }
    public AccountNotFoundException(object id, System.Exception innerException) 
        : base($"Account with {id} Id does not exist!", innerException)
    {
    }
}