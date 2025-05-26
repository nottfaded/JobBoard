using System.Security.Claims;
using JobBoard.Application.DTOs;
using JobBoard.Application.Exception;
using JobBoard.Application.Features;
using JobBoard.Application.Helpers;
using JobBoard.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authServ) : ControllerBase
{
    [HttpPost("register-company")]
    public async Task<IActionResult> RegisterCompany([FromBody] CompanyRegisterRequest request)
    {
        try
        {
            await authServ.RegisterCompanyAsync(request);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok("Registration successful");
    }

    [HttpPost("register-user")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequest request)
    {
        try
        {
            await authServ.RegisterUserAsync(request);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok("Registration successful");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        Account account;

        try
        {
            account = await authServ.LoginAsync(request);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new(ClaimTypes.Email, account.Email),
            new(ClaimTypes.Role, account.GetRole().ToString())
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

        HttpContext.Session.SetString(nameof(account.Id), account.Id.ToString());

        return Ok("Login successful");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return Ok("Logout successful");
    }
}