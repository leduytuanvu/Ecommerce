using Ecommerce.Application.Common.Interfaces.Services.Shipper;
using Ecommerce.Contracts.Shipper.Request;
using Ecommerce.Contracts.Shipper.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("shipper")]
    public class ShipperController : ApiController
    {
        private readonly IShipperService _shipperService;
        private readonly IMapper _mapper;

        public ShipperController(IMapper mapper, IShipperService shipperService)
        {
            _mapper = mapper;
            _shipperService = shipperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Shipper>?> result = await _shipperService.GetAll();

            return result.Match(
                shipperResult => CustomResult("Get data successfully", data: _mapper.Map<List<ShipperResponse>>(shipperResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Shipper?> result = await _shipperService.GetById(id);

            return result.Match(
                shipperResult => CustomResult("Get data successfully", data: _mapper.Map<ShipperResponse>(shipperResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(ShipperCreateRequest request)
        {
            var shipper = _mapper.Map<Shipper>(request);
            ErrorOr<Shipper?> result = await _shipperService.Create(shipper);

            return result.Match(
                shipperResult => CustomResult("Get data successfully", data: _mapper.Map<ShipperResponse>(shipperResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ShipperUpdateRequest request)
        {
            var shipper = _mapper.Map<Shipper>(request);
            ErrorOr<Shipper?> result = await _shipperService.Update(id, shipper);

            return result.Match(
                shipperResult => CustomResult("Get data successfully", data: _mapper.Map<ShipperResponse>(shipperResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Shipper?> result = await _shipperService.Delete(id);

            return result.Match(
                shipperResult => CustomResult("Get data successfully", data: _mapper.Map<ShipperResponse>(shipperResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
