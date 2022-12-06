using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.OrderDetail
{
    public interface IOrderDetailService
    {
        Task<ErrorOr<List<entities.OrderDetail>?>> GetAll();

        Task<ErrorOr<entities.OrderDetail?>> GetById(Guid id);

        Task<ErrorOr<entities.OrderDetail?>> Create(entities.OrderDetail orderDetail);
    }
}
