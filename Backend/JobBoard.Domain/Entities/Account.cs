namespace JobBoard.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public User? User { get; set; }
        public Company? Company { get; set; }
        public Admin? Admin { get; set; }
    }
}
