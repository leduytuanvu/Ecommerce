using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User?> CreateUser(User user);
    }
}
