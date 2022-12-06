using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Order
{
    public interface IOrderService
    {
        Task<ErrorOr<List<entities.Order>?>> GetAll();

        Task<ErrorOr<entities.Order?>> GetById(Guid id);

        Task<ErrorOr<entities.Order?>> Create(entities.Order order);
    }
}
