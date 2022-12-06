using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;


namespace Ecommerce.Application.Common.Interfaces.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<entities.Product?>> Create(entities.Product product)
        {
            var createResponse = await _productRepository.Create(product);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Product?>> Delete(Guid id)
        {
            var deleteResponse = await _productRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Product>?>> GetAll()
        {
            var getAllResponse = await _productRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Product?>> GetById(Guid id)
        {
            var getByIdResponse = await _productRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Product?>> Update(Guid id, entities.Product product)
        {
            var updateResponse = await _productRepository.Update(id, product);
            return updateResponse;
        }
    }
}
