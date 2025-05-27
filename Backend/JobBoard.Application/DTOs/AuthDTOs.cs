namespace JobBoard.Application.DTOs;

public record LoginRequest(string? Email, string? Password);

public record UserRegisterRequest(string? Email, string? Password, string? FirstName, string? LastName, string? PhoneNumber);

public record CompanyRegisterRequest(string? Email, string? Password, string? Name, string? Description, string? Website);