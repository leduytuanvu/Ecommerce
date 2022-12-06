using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            user.CreatedDate = DateTime.Now;
            var response = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<User>?> GetAllUser()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserByPhone(string phone)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User?> GetUserByUsernameAndPassword(LoginRequest request)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);
        }
    }
}
