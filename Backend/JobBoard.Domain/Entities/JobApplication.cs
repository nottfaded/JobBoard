namespace JobBoard.Domain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobVacancyId { get; set; }
        public int UserId { get; set; }
        public string? CoverLetter { get; set; } = null;
        public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
        public JobVacancy JobVacancy { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
