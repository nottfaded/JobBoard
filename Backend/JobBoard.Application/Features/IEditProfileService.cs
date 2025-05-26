using JobBoard.Application.DTOs;

namespace JobBoard.Application.Features;

public interface IEditProfileService
{
    Task UpdateUserAsync(Guid userId, EditUserProfileDto dto);
    Task UpdateCompanyAsync(Guid companyId, EditCompanyProfileDto dto);
}