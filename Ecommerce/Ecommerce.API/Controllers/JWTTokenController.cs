using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {
        public IConfiguration _configuration;

        public readonly EcommerceDbContext _context;

        public JWTTokenController(IConfiguration configuration, EcommerceDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            if(customer != null && customer.Username != null && customer.Password != null)
            {
                var userData = await GetCustomer(customer.Username, customer.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", customer.Id.ToString()),
                        new Claim("Username", customer.Username),
                        new Claim("Password", customer.Password),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: signIn);
                    
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }

        [HttpGet]
        public async Task<Customer?> GetCustomer(string username, string password)
        {
            if(_context.Customers == null)
            {
                return null;
            }
            return await _context.Customers.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
        }
    }
}
