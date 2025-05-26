using JobBoard.Application.Features;
using JobBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobBoard.Infrastructure.Services;

public class CompanyService(JobBoardDbContext dbContext) : ICompanyService
{
    public async Task<IEnumerable<JobVacancy>> GetVacanciesAsync(Guid companyId)
        => await dbContext.JobVacancies.Include(v => v.Company)
            .Where(v => v.CompanyId == companyId)
            .ToListAsync();


}