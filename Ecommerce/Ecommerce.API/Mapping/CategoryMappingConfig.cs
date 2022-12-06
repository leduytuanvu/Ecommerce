using Ecommerce.Contracts.Category.Request;
using Ecommerce.Contracts.Category.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryCreateRequest>();
            config.NewConfig<Category, CategoryUpdateRequest>();
            config.NewConfig<Category, CategoryResponse>();
        }
    }
}
