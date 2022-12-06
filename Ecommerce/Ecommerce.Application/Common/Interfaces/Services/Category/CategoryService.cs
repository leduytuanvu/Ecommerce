using Ecommerce.Application.Persistence;
using Ecommerce.Domain.Common.Errors;
using ErrorOr;
using entities = Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Common.Interfaces.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<entities.Category?>> Create(entities.Category category)
        {
            var createResponse = await _categoryRepository.Create(category);

            if (createResponse is null)
            {
                return CategoryError.CreateError;
            }
            return createResponse;
        }

        public async Task<ErrorOr<entities.Category?>> Delete(Guid id)
        {
            var deleteResponse = await _categoryRepository.Delete(id);
            return deleteResponse;
        }

        public async Task<ErrorOr<List<entities.Category>?>> GetAll()
        {
            var getAllResponse = await _categoryRepository.GetAll();
            return getAllResponse;
        }

        public async Task<ErrorOr<entities.Category?>> GetById(Guid id)
        {
            var getByIdResponse = await _categoryRepository.GetById(id);
            return getByIdResponse;
        }

        public async Task<ErrorOr<entities.Category?>> Update(Guid id, entities.Category category)
        {
            var updateResponse = await _categoryRepository.Update(id, category);
            return updateResponse;
        }
    }
}
