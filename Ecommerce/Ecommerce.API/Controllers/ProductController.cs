using Ecommerce.Application.Common.Interfaces.Services.Product;
using Ecommerce.Contracts.Product.Request;
using Ecommerce.Contracts.Product.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Product>?> result = await _productService.GetAll();

            return result.Match(
                productResult => CustomResult("Get data successfully", data: _mapper.Map<List<ProductResponse>>(productResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Product?> result = await _productService.GetById(id);

            return result.Match(
                productResult => CustomResult("Get data successfully", data: _mapper.Map<ProductResponse>(productResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            var Product = _mapper.Map<Product>(request);
            ErrorOr<Product?> result = await _productService.Create(Product);

            return result.Match(
                productResult => CustomResult("Get data successfully", data: _mapper.Map<ProductResponse>(productResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ProductUpdateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            ErrorOr<Product?> result = await _productService.Update(id, product);

            return result.Match(
                productResult => CustomResult("Get data successfully", data: _mapper.Map<ProductResponse>(productResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Product?> result = await _productService.Delete(id);

            return result.Match(
                productResult => CustomResult("Get data successfully", data: _mapper.Map<ProductResponse>(productResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
