using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public UserRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> CreateUser(User user)
        {
            var response = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }
    }
}
