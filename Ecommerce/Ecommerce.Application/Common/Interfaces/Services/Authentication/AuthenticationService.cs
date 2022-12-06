using Ecommerce.Application.Common.Interfaces.Authentication;
using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Contracts.Authentication.Response;
using Ecommerce.Domain.Common.Errors;
using Ecommerce.Domain.Entities;
using ErrorOr;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Application.Common.Interfaces.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<LoginResponse?>> Login(LoginRequest request)
        {
            // Generate HashPassword
            request.Password = HashPassword(request.Password);

            // Find user by username and password
            var userResponse = await _userRepository.GetUserByUsernameAndPassword(request);

            if (userResponse is null)
            {
                return AuthenticationError.UserNameOrPasswordWrong;
            }
            // Generate token
            var token = _jwtTokenGenerator.GenerateToken(userResponse.Id, request.Username, request.Password);

            // Validate token
            if (string.IsNullOrEmpty(token))
            {
                return AuthenticationError.TokenGenerationFailed;
            }

            var response = new LoginResponse();
            response.Id = userResponse.Id;
            response.Username = userResponse.Username;
            response.Password = userResponse.Password;
            response.Email = userResponse.Email;
            response.Phone = userResponse.Phone;
            response.Avatar = userResponse.Avatar;
            response.Token = token;

            return response;

        }

        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }

        public async Task<ErrorOr<RegisterResponse?>> Register(RegisterRequest request)
        {
            // CHECK USERNAME EXIST OR NOT
            if (await _userRepository.GetUserByUsername(request.Username) is not null)
            {
                return AuthenticationError.DuplicateUsername;
            }

            // CHECK PASSWORD WEEK
            if (request.Password.Length < 5)
            {
                return AuthenticationError.PasswordWeek;
            }

            // CHECK PASSWORD AND REPASSWORD NOT MATCH
            if (!request.Password.Equals(request.RePassword))
            {
                return AuthenticationError.CheckPasswordWithRepassword;
            }

            // CHECK USER NAME IS EMPTY
            if (string.IsNullOrEmpty(request.Username) || request.Username.Length < 5)
            {
                return AuthenticationError.UsernameIsEmpty;
            }

            // CHECK PASSWORD IS EMPTY
            if (string.IsNullOrEmpty(request.Password))
            {
                return AuthenticationError.PasswordIsEmpty;
            }

            // CHECK PHONE IS EMPTY
            if (string.IsNullOrEmpty(request.Phone))
            {
                return AuthenticationError.PhoneIsEmpty;
            }

            // CHECK EMAIL IS EMPTY
            if (string.IsNullOrEmpty(request.Email))
            {
                return AuthenticationError.EmailIsEmpty;
            }

            // CHECK FULL NAME IS EMPTY
            if (string.IsNullOrEmpty(request.FullName))
            {
                return AuthenticationError.FullNameIsEmpty;
            }

            // CREATE USER IN DATABASE
            User user = new()
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Password = HashPassword(request.Password),
                Email = request.Email,
                Phone = request.Phone,
                FullName = request.FullName,
            };
            var createResponse = await _userRepository.CreateUser(user);
            if (createResponse is not null)
            {
                // GENERATE TOKEN
                string token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username, user.Password);
                if (string.IsNullOrEmpty(token))
                {
                    return AuthenticationError.TokenGenerationFailed;
                }

                var response = new RegisterResponse();
                response.Id = user.Id;
                response.Username = user.Username;
                response.Password = user.Password;
                response.Email = user.Email;
                response.Phone = user.Phone;
                response.FullName = user.FullName;
                response.Token = token;

                return response;
            }
            return AuthenticationError.CreateUserFaild;
        }
    }
}
