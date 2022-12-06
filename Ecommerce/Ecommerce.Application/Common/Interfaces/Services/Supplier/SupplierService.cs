using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Supplier
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<ErrorOr<entities.Supplier?>> Create(entities.Supplier supplier)
        {
            var createResponse = await _supplierRepository.Create(supplier);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Supplier?>> Delete(Guid id)
        {
            var deleteResponse = await _supplierRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Supplier>?>> GetAll()
        {
            var getAllResponse = await _supplierRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Supplier?>> GetById(Guid id)
        {
            var getByIdResponse = await _supplierRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Supplier?>> Update(Guid id, entities.Supplier supplier)
        {
            var updateResponse = await _supplierRepository.Update(id, supplier);
            return updateResponse;
        }
    }
}
