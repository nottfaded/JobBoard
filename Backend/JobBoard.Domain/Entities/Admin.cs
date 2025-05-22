namespace JobBoard.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
    }
}
