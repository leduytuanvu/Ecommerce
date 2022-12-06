using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Category
{
    public interface ICategoryService
    {
        Task<ErrorOr<List<entities.Category>?>> GetAll();

        Task<ErrorOr<entities.Category?>> GetById(Guid id);

        Task<ErrorOr<entities.Category?>> Create(entities.Category category);

        Task<ErrorOr<entities.Category?>> Update(Guid id, entities.Category category);

        Task<ErrorOr<entities.Category?>> Delete(Guid id);
    }
}
