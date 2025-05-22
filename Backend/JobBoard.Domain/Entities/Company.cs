namespace JobBoard.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = null;
        public string? Website { get; set; } = null;
        public Account Account { get; set; } = null!;
        public ICollection<JobVacancy> JobVacancies { get; set; } = new List<JobVacancy>();
    }
}
