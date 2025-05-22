namespace JobBoard.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = null;
        public string? CvPath { get; set; } = null;
        public Account Account { get; set; } = null!;
    }
}
