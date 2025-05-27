using FluentValidation;
using JobBoard.Application.DTOs;

namespace JobBoard.Application.Validators.AuthDTOs;

public class UserRegisterRequestValidation : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterRequestValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        RuleFor(x => x.FirstName)
            .NotEmpty();
        RuleFor(x => x.LastName)
            .NotEmpty();
        RuleFor(x => x.PhoneNumber)
            .MaximumLength(11);
    }
}