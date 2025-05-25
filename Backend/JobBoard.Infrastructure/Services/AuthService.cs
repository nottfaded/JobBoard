using JobBoard.Application.DTOs;
using JobBoard.Application.Exception;
using JobBoard.Application.Features;
using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Infrastructure.Services;

public class AuthService(JobBoardDbContext dbContext) : IAuthService
{
    public async Task<Account> LoginAsync(LoginRequest request)
    {
        var account = await dbContext.Accounts.FirstOrDefaultAsync(i => i.Email == request.Email);

        if (account == null || account.Password != request.Password)
            throw new Exception("Invalid email or password");

        return account;
    }

    public async Task<User> RegisterUserAsync(UserRegisterRequest request)
    {
        if (await dbContext.Accounts.AnyAsync(a => a.Email == request.Email))
            throw new EmailAlreadyExistsException(request.Email);

        var user = new User
        {
            Email = request.Email,
            Password = request.Password, // TODO: add hashing
            FirstName = request.FirstName,
            LastName = request.LastName,
        };
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<Company> RegisterCompanyAsync(CompanyRegisterRequest request)
    {
        if (await dbContext.Accounts.AnyAsync(a => a.Email == request.Email))
            throw new EmailAlreadyExistsException(request.Email);

        var company = new Company
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password, // TODO: add hashing
            Description = request.Description,
            Website = request.Website
        };
        await dbContext.Companies.AddAsync(company);
        await dbContext.SaveChangesAsync();

        return company;
    }
}