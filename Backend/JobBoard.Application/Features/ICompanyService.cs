using JobBoard.Domain.Entities;

namespace JobBoard.Application.Features;

public interface ICompanyService
{
    Task<IEnumerable<JobVacancy>> GetVacanciesAsync(Guid companyId);
}