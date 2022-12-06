using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<ErrorOr<List<entities.Product>?>> GetAll();

        Task<ErrorOr<entities.Product?>> GetById(Guid id);

        Task<ErrorOr<entities.Product?>> Create(entities.Product product);

        Task<ErrorOr<entities.Product?>> Update(Guid id, entities.Product product);

        Task<ErrorOr<entities.Product?>> Delete(Guid id);
    }
}
