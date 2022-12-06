using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IOrderRepository
    {
        Task<List<Order>?> GetAll();

        Task<Order?> GetById(Guid id);

        Task<Order?> Create(Order order);
    }
}
