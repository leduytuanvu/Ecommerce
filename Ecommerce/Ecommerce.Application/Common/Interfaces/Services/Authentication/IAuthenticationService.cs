using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Contracts.Authentication.Response;
using ErrorOr;

namespace Ecommerce.Application.Common.Interfaces.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<ErrorOr<LoginResponse?>> Login(LoginRequest request);

        Task<ErrorOr<RegisterResponse?>> Register(RegisterRequest request);
    }
}
