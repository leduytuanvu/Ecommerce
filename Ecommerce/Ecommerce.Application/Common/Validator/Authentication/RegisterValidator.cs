using Ecommerce.Contracts.Authentication.Requests;
using FluentValidation;

namespace Ecommerce.Application.Common.Validator.Authentication
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required");
        }
    }
}
