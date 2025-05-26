using JobBoard.Application.DTOs;
using JobBoard.Application.Exception;
using JobBoard.Application.Features;
using JobBoard.Domain.Entities;
using JobBoard.Domain.Enums;

namespace JobBoard.Infrastructure.Services;

public class VacancyService(JobBoardDbContext dbContext, ICompanyService companyServ) : IVacancyService
{
    public async Task CreateAsync(Guid companyId, CreateVacancyDto vacancyDto)
    {
        if (!Enum.TryParse(vacancyDto.SalaryTypeId.ToString(), out SalaryType salaryType))
            throw new ArgumentException("Invalid SalaryTypeId");

        var company = await dbContext.FindAsync<Company>(companyId);

        if (company is null) throw new AccountNotFoundException(companyId);

        var vacancy = new JobVacancy
        {
            CompanyId = companyId,
            Bet = vacancyDto.Bet,
            SalaryType = salaryType,
            Title = vacancyDto.Title,
            Description = vacancyDto.Description,
            Location = vacancyDto.Location
        };

        dbContext.JobVacancies.Add(vacancy);

        await dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(Guid companyId, EditVacancyDto vacancyDto)
    {
        if(!Enum.TryParse(vacancyDto.SalaryTypeId.ToString(), out SalaryType salaryType))
            throw new ArgumentException("Invalid SalaryTypeId");

        var company = await dbContext.FindAsync<Company>(companyId);
        if (company is null) throw new AccountNotFoundException(companyId);

        var allVacancies = await companyServ.GetVacanciesAsync(companyId);
        var vacancy = allVacancies.FirstOrDefault(v => v.Id == vacancyDto.Id);

        if (vacancy is null) throw new VacancyNotFoundException(vacancyDto.Id);

        vacancy.Bet = vacancyDto.Bet;
        vacancy.SalaryType = salaryType;
        vacancy.Title = vacancyDto.Title;
        vacancy.Description = vacancyDto.Description;
        vacancy.Location = vacancyDto.Location;
        vacancy.IsActive = vacancyDto.IsActive;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid companyId, int vacancyId)
    {
        var company = await dbContext.FindAsync<Company>(companyId);
        if (company is null) throw new AccountNotFoundException(companyId);

        var allVacancies = await companyServ.GetVacanciesAsync(companyId);
        var vacancy = allVacancies.FirstOrDefault(v => v.Id == vacancyId);

        if (vacancy is null) throw new VacancyNotFoundException(vacancyId);

        dbContext.JobVacancies.Remove(vacancy);

        await dbContext.SaveChangesAsync();
    }
}