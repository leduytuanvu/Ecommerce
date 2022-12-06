using ErrorOr;
using entities = Ecommerce.Domain.Entities;


namespace Ecommerce.Application.Common.Interfaces.Services.Image
{
    public interface IImageService
    {
        Task<ErrorOr<List<entities.Image>?>> GetAll();

        Task<ErrorOr<entities.Image?>> GetById(Guid id);

        Task<ErrorOr<entities.Image?>> Create(entities.Image image);

        Task<ErrorOr<entities.Image?>> Update(Guid id, entities.Image image);

        Task<ErrorOr<entities.Image?>> Delete(Guid id);
    }
}
