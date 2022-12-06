using Ecommerce.Contracts.Shipper.Request;
using Ecommerce.Contracts.Shipper.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class ShipperMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Shipper, ShipperCreateRequest>();
            config.NewConfig<Shipper, ShipperUpdateRequest>();
            config.NewConfig<Shipper, ShipperResponse>();
        }
    }
}
