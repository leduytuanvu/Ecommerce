using Ecommerce.Contracts.Supplier.Request;
using Ecommerce.Contracts.Supplier.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class SupplierMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Supplier, SupplierCreateRequest>();
            config.NewConfig<Supplier, SupplierUpdateRequest>();
            config.NewConfig<Supplier, SupplierResponse>();
        }
    }
}
