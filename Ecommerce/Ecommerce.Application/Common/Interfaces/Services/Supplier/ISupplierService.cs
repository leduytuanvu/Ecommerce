using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Supplier
{
    public interface ISupplierService
    {
        Task<ErrorOr<List<entities.Supplier>?>> GetAll();

        Task<ErrorOr<entities.Supplier?>> GetById(Guid id);

        Task<ErrorOr<entities.Supplier?>> Create(entities.Supplier supplier);

        Task<ErrorOr<entities.Supplier?>> Update(Guid id, entities.Supplier supplier);

        Task<ErrorOr<entities.Supplier?>> Delete(Guid id);
    }
}
