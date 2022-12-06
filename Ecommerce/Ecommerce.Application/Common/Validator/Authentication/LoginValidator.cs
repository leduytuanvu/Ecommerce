using Ecommerce.Contracts.Authentication.Requests;
using FluentValidation;

namespace Ecommerce.Application.Common.Validator.Authentication
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
