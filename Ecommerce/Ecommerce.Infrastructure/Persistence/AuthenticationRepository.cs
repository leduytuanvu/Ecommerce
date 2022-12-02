using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public AuthenticationRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string?> CheckUsernameExistOrNotExist(string username)
        {
            return await _dbContext.Users!
                .Where(x => x.Username == username)
                .Select(x => x.Username)
                .FirstOrDefaultAsync();
        }
    }
}
