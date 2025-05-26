using System.ComponentModel.DataAnnotations;

namespace JobBoard.Domain.Entities;

public class JobApplication
{
    [Key]
    public int Id { get; set; }
    public int JobVacancyId { get; set; }
    public Guid UserId { get; set; }
    public string? CoverLetter { get; set; } = null;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public JobVacancy JobVacancy { get; set; } = null!;
    public User User { get; set; } = null!;
}