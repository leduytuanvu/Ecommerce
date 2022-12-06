using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetAll();

        Task<Product?> GetById(Guid id);

        Task<Product?> Create(Product product);

        Task<Product?> Update(Guid id, Product product);

        Task<Product?> Delete(Guid id);
    }
}
