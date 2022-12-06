using Ecommerce.Application.Common.Interfaces.Services.Supplier;
using Ecommerce.Contracts.Supplier.Request;
using Ecommerce.Contracts.Supplier.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("supplier")]
    public class SupplierController : ApiController
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SupplierController(IMapper mapper, ISupplierService supplierService)
        {
            _mapper = mapper;
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Supplier>?> result = await _supplierService.GetAll();

            return result.Match(
                shupplierResult => CustomResult("Get data successfully", data: _mapper.Map<List<SupplierResponse>>(shupplierResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Supplier?> result = await _supplierService.GetById(id);

            return result.Match(
                shupplierResult => CustomResult("Get data successfully", data: _mapper.Map<SupplierResponse>(shupplierResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateRequest request)
        {
            var supplier = _mapper.Map<Supplier>(request);
            ErrorOr<Supplier?> result = await _supplierService.Create(supplier);

            return result.Match(
                shupplierResult => CustomResult("Get data successfully", data: _mapper.Map<SupplierResponse>(shupplierResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, SupplierUpdateRequest request)
        {
            var category = _mapper.Map<Supplier>(request);
            ErrorOr<Supplier?> result = await _supplierService.Update(id, category);

            return result.Match(
                shupplierResult => CustomResult("Get data successfully", data: _mapper.Map<SupplierResponse>(shupplierResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Supplier?> result = await _supplierService.Delete(id);

            return result.Match(
                shupplierResult => CustomResult("Get data successfully", data: _mapper.Map<SupplierResponse>(shupplierResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
