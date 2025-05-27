using JobBoard.Application.DTOs;
using JobBoard.Application.Extensions;
using JobBoard.Application.Features;
using JobBoard.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IVacancyService vacancyServ) : ControllerBase
{
    [HttpPost("create")]
    [Authorize(Roles = nameof(AccountRole.Company))]
    public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyDto dto)
    {
        var companyId = HttpContext.User.GetAccountId();
        await vacancyServ.CreateAsync(companyId, dto);

        return Ok("Vacancy created successfully");
    }

    [HttpPut("edit")]
    [Authorize(Roles = nameof(AccountRole.Company))]
    public async Task<IActionResult> EditVacancy([FromBody] EditVacancyDto dto)
    {
        var companyId = HttpContext.User.GetAccountId();
        await vacancyServ.EditAsync(companyId, dto);

        return Ok("Vacancy edited successfully");
    }

    [HttpDelete("delete/{vacancyId}")]
    [Authorize(Roles = nameof(AccountRole.Company))]
    public async Task<IActionResult> DeleteVacancy([FromRoute] int vacancyId)
    {
        var companyId = HttpContext.User.GetAccountId();
        await vacancyServ.DeleteAsync(companyId, vacancyId);

        return Ok("Vacancy deleted successfully");
    }
}