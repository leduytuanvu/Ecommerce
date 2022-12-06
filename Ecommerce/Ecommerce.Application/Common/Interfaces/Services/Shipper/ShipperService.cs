using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;
namespace Ecommerce.Application.Common.Interfaces.Services.Shipper
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<ErrorOr<entities.Shipper?>> Create(entities.Shipper shipper)
        {
            var createResponse = await _shipperRepository.Create(shipper);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Shipper?>> Delete(Guid id)
        {
            var deleteResponse = await _shipperRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Shipper>?>> GetAll()
        {
            var getAllResponse = await _shipperRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Shipper?>> GetById(Guid id)
        {
            var getByIdResponse = await _shipperRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Shipper?>> Update(Guid id, entities.Shipper shipper)
        {
            var updateResponse = await _shipperRepository.Update(id, shipper);
            return updateResponse;
        }
    }
}
