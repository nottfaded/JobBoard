namespace JobBoard.Application.Exception;

public class VacancyNotFoundException : System.Exception
{
    public VacancyNotFoundException(object id) : base($"Vacancy with {id} Id does not exist!")
    {
    }
    public VacancyNotFoundException(object id, System.Exception innerException)
        : base($"Vacancy with {id} Id does not exist!", innerException)
    {
    }
}