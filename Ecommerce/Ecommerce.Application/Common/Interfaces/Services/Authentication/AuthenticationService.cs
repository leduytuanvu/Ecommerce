
using Ecommerce.Application.Common.Interfaces.Authentication;
using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Contracts.Authentication.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationRepository _auththenticationRepository;

        public AuthenticationService(IUserRepository userRepository, IAuthenticationRepository auththenticationRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _auththenticationRepository = auththenticationRepository;
        }

        ////public async Task<LoginResponse> Login(string Username, string Password)
        ////{
        ////    // Validate username and password
        ////    //if (_userRepository.GetUserByUsernameAndPassword(username, password))
        ////    //{
        ////    //    // Generate token
        ////    //    var token = _jwtTokenGenerator.GenerateToken(username, password);

        ////    //    // Return token
        ////    //    return new LoginResponse
        ////    //    {
        ////    //        Token = token
        ////    //    };
        ////    //}

        ////    // Generate token
        ////    //var response = new LoginResponse();
        ////    //response.Id = Guid.NewGuid();
        ////    //response.Username = username;
        ////    //response.Password = password;
        ////    //response.Email = password;
        ////    //response.Phone = password;
        ////    //response.Avatar = password;
        ////    //return response;
        ////}

        public async Task<RegisterResponse?> Register(RegisterRequest request)
        {
            //CHECK USERNAME EXIST OR NOT
            if (await _auththenticationRepository.CheckUsernameExistOrNotExist(request.Username) is not null)
            {
                return null;
            }

            // CREATE USER IN DATABASE
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Phone = request.Phone,
                FullName = request.FullName,
            };
            await _userRepository.CreateUser(user);

            // GENERATE TOKEN
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Password);
            var response = new RegisterResponse
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
                FullName = user.FullName,
                Token = token
            };
            return response;
        }
    }
}
