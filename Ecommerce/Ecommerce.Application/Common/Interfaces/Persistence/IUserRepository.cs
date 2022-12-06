using Ecommerce.Contracts.Authentication.Requests;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);

        Task<User?> GetUserByUsernameAndPassword(LoginRequest request);

        Task<User?> GetUserByUsername(string username);

        Task<User?> GetUserByEmail(string email);

        Task<User?> GetUserByPhone(string phone);

        Task<List<User>?> GetAllUser();
    }
}
