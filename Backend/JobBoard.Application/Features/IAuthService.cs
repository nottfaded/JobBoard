using JobBoard.Application.DTOs;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Features;

public interface IAuthService
{
    Task<Account> LoginAsync(LoginRequest request);
    Task<User> RegisterUserAsync(UserRegisterRequest request);
    Task<Company> RegisterCompanyAsync(CompanyRegisterRequest request);
}