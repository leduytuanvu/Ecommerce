using Ecommerce.Contracts.OrderDetail.Request;
using Ecommerce.Contracts.OrderDetail.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class OrderDetailMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderDetail, OrderDetailCreateRequest>();
            config.NewConfig<OrderDetail, OrderDetailResponse>();
        }
    }
}
