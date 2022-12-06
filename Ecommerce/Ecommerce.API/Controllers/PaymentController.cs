using Ecommerce.Application.Common.Interfaces.Services.Payment;
using Ecommerce.Contracts.Payment.Request;
using Ecommerce.Contracts.Payment.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("payment")]
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IMapper mapper, IPaymentService paymentService)
        {
            _mapper = mapper;
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Payment>?> result = await _paymentService.GetAll();

            return result.Match(
                paymentResult => CustomResult("Get data successfully", data: _mapper.Map<List<PaymentResponse>>(paymentResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Payment?> result = await _paymentService.GetById(id);

            return result.Match(
                paymentResult => CustomResult("Get data successfully", data: _mapper.Map<PaymentResponse>(paymentResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(PaymentCreateRequest request)
        {
            var Product = _mapper.Map<Payment>(request);
            ErrorOr<Payment?> result = await _paymentService.Create(Product);

            return result.Match(
                paymentResult => CustomResult("Get data successfully", data: _mapper.Map<PaymentResponse>(paymentResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, PaymentUpdateRequest request)
        {
            var product = _mapper.Map<Payment>(request);
            ErrorOr<Payment?> result = await _paymentService.Update(id, product);

            return result.Match(
                paymentResult => CustomResult("Get data successfully", data: _mapper.Map<PaymentResponse>(paymentResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Payment?> result = await _paymentService.Delete(id);

            return result.Match(
                paymentResult => CustomResult("Get data successfully", data: _mapper.Map<PaymentResponse>(paymentResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
