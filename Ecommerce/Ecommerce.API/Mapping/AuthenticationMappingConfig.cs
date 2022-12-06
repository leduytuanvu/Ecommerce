using Ecommerce.Contracts.Authentication.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.Application.Common.Interfaces.Services.DateTimeProvider
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, LoginResponse>();
            config.NewConfig<User, RegisterResponse>();
        }
    }
}
