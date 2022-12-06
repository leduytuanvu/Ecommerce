using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Persistence
{
    public interface IImageRepository
    {
        Task<List<Image>?> GetAll();

        Task<Image?> GetById(Guid id);

        Task<Image?> Create(Image image);

        Task<Image?> Update(Guid id, Image image);

        Task<Image?> Delete(Guid id);
    }
}
