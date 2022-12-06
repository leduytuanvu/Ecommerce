using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;


namespace Ecommerce.Application.Common.Interfaces.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<ErrorOr<entities.Image?>> Create(entities.Image image)
        {
            var createResponse = await _imageRepository.Create(image);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Image?>> Delete(Guid id)
        {
            var deleteResponse = await _imageRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Image>?>> GetAll()
        {
            var getAllResponse = await _imageRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Image?>> GetById(Guid id)
        {
            var getByIdResponse = await _imageRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Image?>> Update(Guid id, entities.Image image)
        {
            var updateResponse = await _imageRepository.Update(id, image);
            return updateResponse;
        }
    }
}
