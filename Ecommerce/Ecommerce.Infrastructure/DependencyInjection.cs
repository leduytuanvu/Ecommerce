using Ecommerce.Application.Common.Interfaces.Authentication;
using Ecommerce.Application.Common.Interfaces.Services.DateTimeProvider;
using Ecommerce.Infrastructure.Authentication;
using Ecommerce.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ecommerce.Application.Common.Interfaces.Persistence;
using Ecommerce.Infrastructure.Persistence;

namespace Ecommerce.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
            return services;
        }
    }
}
