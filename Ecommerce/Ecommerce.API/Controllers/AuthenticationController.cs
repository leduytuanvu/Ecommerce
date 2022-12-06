using Ecommerce.Application.Common.Interfaces.Services.Authentication;
using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Contracts.Authentication.Response;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            ErrorOr<RegisterResponse?> result = await _authenticationService.Register(request);

            return result.Match(
                authResult => CustomResult("Get data successfully", data: authResult),
                errors => CustomResultError(errors)
            );
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            ErrorOr<LoginResponse?> result = await _authenticationService.Login(request);

            return result.Match(
                authResult => CustomResult("Get data successfully", data: authResult),
                errors => CustomResultError(errors)
            );
        }
    }
}
