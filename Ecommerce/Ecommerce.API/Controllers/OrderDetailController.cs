using Ecommerce.Application.Common.Interfaces.Services.OrderDetail;
using Ecommerce.Contracts.OrderDetail.Request;
using Ecommerce.Contracts.OrderDetail.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("order-detail")]
    public class OrderDetailController : ApiController
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<OrderDetail>?> result = await _orderDetailService.GetAll();

            return result.Match(
                orderDetailResult => CustomResult("Get data successfully", data: _mapper.Map<List<OrderDetailResponse>>(orderDetailResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<OrderDetail?> result = await _orderDetailService.GetById(id);

            return result.Match(
                orderDetailResult => CustomResult("Get data successfully", data: _mapper.Map<OrderDetailResponse>(orderDetailResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(OrderDetailCreateRequest request)
        {
            ErrorOr<OrderDetail?> result = await _orderDetailService.Create(_mapper.Map<OrderDetail>(request));

            return result.Match(
                orderDetailResult => CustomResult("Get data successfully", data: _mapper.Map<OrderDetailResponse>(orderDetailResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
