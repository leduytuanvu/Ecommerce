using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Shipper
{
    public interface IShipperService
    {
        Task<ErrorOr<List<entities.Shipper>?>> GetAll();

        Task<ErrorOr<entities.Shipper?>> GetById(Guid id);

        Task<ErrorOr<entities.Shipper?>> Create(entities.Shipper shipper);

        Task<ErrorOr<entities.Shipper?>> Update(Guid id, entities.Shipper shipper);

        Task<ErrorOr<entities.Shipper?>> Delete(Guid id);
    }
}
