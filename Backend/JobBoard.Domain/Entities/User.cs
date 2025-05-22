namespace JobBoard.Domain.Entities;

public class User : Account
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; } = null;
    public string? CvPath { get; set; } = null;
}