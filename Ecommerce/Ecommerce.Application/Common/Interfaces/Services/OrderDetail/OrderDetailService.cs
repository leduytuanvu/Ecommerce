using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.OrderDetail
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<ErrorOr<entities.OrderDetail?>> Create(entities.OrderDetail orderDetail)
        {
            var createResponse = await _orderDetailRepository.Create(orderDetail);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<List<entities.OrderDetail>?>> GetAll()
        {
            var getAllResponse = await _orderDetailRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.OrderDetail?>> GetById(Guid id)
        {
            var getByIdResponse = await _orderDetailRepository.GetById(id);
            return getByIdResponse;
        }
    }
}
