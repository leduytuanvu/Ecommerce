using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>?> GetAll();

        Task<OrderDetail?> GetById(Guid id);

        Task<OrderDetail?> Create(OrderDetail orderDetail);
    }
}
