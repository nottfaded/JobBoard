using JobBoard.Application.DTOs;
using JobBoard.Domain.Entities;

namespace JobBoard.Application.Features;

public interface IVacancyService
{
    Task CreateAsync(Guid companyId, CreateVacancyDto vacancyDto);
    Task EditAsync(Guid companyId, EditVacancyDto vacancyDto);
    Task DeleteAsync(Guid companyId, int vacancyId);
}