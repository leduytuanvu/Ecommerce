using Ecommerce.Application.Services.Authentication;
using Ecommerce.Contracts.Authentication.Requests;
using Microsoft.AspNetCore.Mvc;
using CoreApiResponse;
using MapsterMapper;
using Ecommerce.Domain.Entities;

namespace Ecommerce.API.Controllers
{

    [ApiController]
    [Route("auth")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authenticationService.Register(request);
            var demo = _mapper.Map<User>(response);

            return CustomResult("Data loaded successfully", demo);
        }

        //[Route("login")]
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginRequest request)
        //{
        //    return Ok(_authenticationService.Login(request.Username, request.Password));
        //}
    }
}
