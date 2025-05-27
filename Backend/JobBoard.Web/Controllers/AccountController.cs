using JobBoard.Application.DTOs;
using JobBoard.Application.Features;
using JobBoard.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using JobBoard.Application.Extensions;

namespace JobBoard.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(IEditProfileService editServ) : ControllerBase
{
    [HttpPut("user/edit-profile")]
    [Authorize(Roles = nameof(AccountRole.User))]
    public async Task<IActionResult> EditUserProfile([FromBody] EditUserProfileDto dto)
    {
        var userId = HttpContext.User.GetAccountId();
        await editServ.UpdateUserAsync(userId, dto);

        return Ok("Profile updated successfully");
    }

    [HttpPut("company/edit-profile")]
    [Authorize(Roles = nameof(AccountRole.Company))]
    public async Task<IActionResult> EditCompanyProfile([FromBody] EditCompanyProfileDto dto)
    {
        var companyId = HttpContext.User.GetAccountId();
        await editServ.UpdateCompanyAsync(companyId, dto);

        return Ok("Profile updated successfully");
    }
}