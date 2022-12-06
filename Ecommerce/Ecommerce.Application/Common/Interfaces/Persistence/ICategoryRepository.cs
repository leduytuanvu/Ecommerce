using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Persistence
{
    public interface ICategoryRepository
    {
        Task<List<Category>?> GetAll();

        Task<Category?> GetById(Guid id);

        Task<Category?> Create(Category category);

        Task<Category?> Update(Guid id, Category category);

        Task<Category?> Delete(Guid id);
    }
}
