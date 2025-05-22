namespace JobBoard.Domain.Entities;

public class Company : Account
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
    public string? Website { get; set; } = null;
    public ICollection<JobVacancy> JobVacancies { get; set; } = new List<JobVacancy>();
}