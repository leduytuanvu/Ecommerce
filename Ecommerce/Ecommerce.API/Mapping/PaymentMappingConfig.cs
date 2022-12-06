using Ecommerce.Contracts.Payment.Request;
using Ecommerce.Contracts.Payment.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class PaymentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Payment, PaymentCreateRequest>();
            config.NewConfig<Payment, PaymentUpdateRequest>();
            config.NewConfig<Payment, PaymentResponse>();
        }
    }
}
