using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IShipperRepository
    {
        Task<List<Shipper>?> GetAll();

        Task<Shipper?> GetById(Guid id);

        Task<Shipper?> Create(Shipper shipper);

        Task<Shipper?> Update(Guid id, Shipper shipper);

        Task<Shipper?> Delete(Guid id);
    }
}
