using Ecommerce.Application.Common.Interfaces.Services.Order;
using Ecommerce.Contracts.Order.Request;
using Ecommerce.Contracts.Order.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("order")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _orderService = OrderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Order>?> result = await _orderService.GetAll();

            return result.Match(
                orderResult => CustomResult("Get data successfully", data: _mapper.Map<List<OrderResponse>>(orderResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Order?> result = await _orderService.GetById(id);

            return result.Match(
                orderResult => CustomResult("Get data successfully", data: _mapper.Map<OrderResponse>(orderResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request)
        {
            ErrorOr<Order?> result = await _orderService.Create(_mapper.Map<Order>(request));

            return result.Match(
                orderResult => CustomResult("Get data successfully", data: _mapper.Map<OrderResponse>(orderResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
