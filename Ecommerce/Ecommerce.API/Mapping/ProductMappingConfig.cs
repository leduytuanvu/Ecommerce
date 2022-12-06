using Ecommerce.Contracts.Product.Request;
using Ecommerce.Contracts.Product.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductCreateRequest>();
            config.NewConfig<Product, ProductUpdateRequest>();
            config.NewConfig<Product, ProductResponse>();
        }
    }
}
