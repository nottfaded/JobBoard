namespace JobBoard.Domain.Entities
{
    public class JobVacancy
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int SalaryTypeId { get; set; }
        public long Bet { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Location { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public Company Company { get; set; } = null!;
        public SalaryType SalaryType { get; set; } = null!;
    }
}
