using Ecommerce.Contracts.Authentication.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, LoginResponse>();
        }
    }
}
