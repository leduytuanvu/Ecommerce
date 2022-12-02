using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Contracts.Authentication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        //Task<LoginResponse> Login(string Username, string Password);

        Task<RegisterResponse?> Register(RegisterRequest request);
    }
}
