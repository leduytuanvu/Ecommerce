using Ecommerce.Contracts.Order.Request;
using Ecommerce.Contracts.Order.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderCreateRequest>();
            config.NewConfig<Order, OrderResponse>();
        }
    }
}
