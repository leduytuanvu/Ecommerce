using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ErrorOr<entities.Order?>> Create(entities.Order order)
        {
            var createResponse = await _orderRepository.Create(order);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<List<entities.Order>?>> GetAll()
        {
            var getAllResponse = await _orderRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Order?>> GetById(Guid id)
        {
            var getByIdResponse = await _orderRepository.GetById(id);
            return getByIdResponse;
        }
    }
}
