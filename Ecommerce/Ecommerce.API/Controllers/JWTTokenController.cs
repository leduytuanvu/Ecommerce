//using AutoMapper;
//using CoreApiResponse;
//using Ecommerce.Domain.Entities;
//using Ecommerce.Domain.Requests.Login;
//using Ecommerce.Domain.Responses.LoginResponses;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Net;
//using System.Security.Claims;
//using System.Text;

//namespace Ecommerce.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class JWTTokenController : BaseController
//    {
//        public IConfiguration _configuration;
//        public readonly EcommerceDbContext _context;
//        private readonly IMapper _mapper;

//        public JWTTokenController(IConfiguration configuration, EcommerceDbContext context, IMapper mapper)
//        {
//            _configuration = configuration;
//            _context = context;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(LoginRequest request)
//        {
//            if (request != null && request.Username != null && request.Password != null)
//            {
//                var userData = await GetUser(request.Username, request.Password);
//                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
//                if (userData != null)
//                {
//                    var claims = new[]
//                    {
//                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
//                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                        new Claim("Id", userData.Id.ToString()),
//                        new Claim("Username", userData.Username),
//                        new Claim("Password", userData.Password),
//                    };

//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
//                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//                    var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: signIn);
//                    userData.Token = new JwtSecurityTokenHandler().WriteToken(token);
//                    return CustomResult("Data loaded successfully", userData);
//                }
//                else
//                {
//                    return CustomResult("User name or password wrong", HttpStatusCode.NotFound);
//                }
//            }
//            else
//            {
//                return CustomResult("User name and password must not empty", HttpStatusCode.BadRequest);
//            }
//        }

//        [HttpGet]
//        public async Task<LoginResponse?> GetUser(string username, string password)
//        {
//            if (_context.Users == null)
//            {
//                return null;
//            }
//            var response = await _context.Users.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
//            var result = _mapper.Map<LoginResponse>(response);
//            return result;
//        }
//    }
//}
