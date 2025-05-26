using System.ComponentModel.DataAnnotations;

namespace JobBoard.Domain.Entities;

public abstract class Account
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}