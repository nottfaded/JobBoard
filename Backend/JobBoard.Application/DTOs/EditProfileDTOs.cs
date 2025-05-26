namespace JobBoard.Application.DTOs;

public record EditUserProfileDto(string? PhoneNumber = null, string? CvPath = null)
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}

public record EditCompanyProfileDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Website { get; init; } = string.Empty;
}