using JobBoard.Application.DTOs;
using JobBoard.Application.Exception;
using JobBoard.Application.Features;

namespace JobBoard.Infrastructure.Services;

internal class EditProfileService(JobBoardDbContext dbContext) : IEditProfileService
{
    public async Task UpdateUserAsync(Guid userId, EditUserProfileDto dto)
    {
        var user = await dbContext.Users.FindAsync(userId);

        if (user is null) throw new AccountNotFoundException(userId.ToString());

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Email = dto.Email;
        user.PhoneNumber = dto.PhoneNumber;
        user.CvPath = dto.CvPath;

        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateCompanyAsync(Guid companyId, EditCompanyProfileDto dto)
    {
        var company = await dbContext.Companies.FindAsync(companyId);
        
        if (company is null) throw new AccountNotFoundException(companyId.ToString());

        company.Email = dto.Email;
        company.Name = dto.Name;
        company.Description = dto.Description;
        company.Website = dto.Website;

        await dbContext.SaveChangesAsync();
    }
}