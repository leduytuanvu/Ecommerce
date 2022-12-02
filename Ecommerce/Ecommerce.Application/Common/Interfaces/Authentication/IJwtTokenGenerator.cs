namespace Ecommerce.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid Id, string Username, string Password);
    }
}
