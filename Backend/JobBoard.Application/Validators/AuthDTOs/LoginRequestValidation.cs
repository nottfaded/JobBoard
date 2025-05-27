using FluentValidation;
using JobBoard.Application.DTOs;

namespace JobBoard.Application.Validators.AuthDTOs;

public class LoginRequestValidation : AbstractValidator<LoginRequest>
{
    public LoginRequestValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}