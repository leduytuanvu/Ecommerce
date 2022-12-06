using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>?> GetAll();

        Task<Supplier?> GetById(Guid id);

        Task<Supplier?> Create(Supplier supplier);

        Task<Supplier?> Update(Guid id, Supplier supplier);

        Task<Supplier?> Delete(Guid id);
    }
}
