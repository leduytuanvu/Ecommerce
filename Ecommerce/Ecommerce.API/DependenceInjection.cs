using Ecommerce.API.Mapping;

namespace Ecommerce.API
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add services to the container && SET UP JWT
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // ADD DEPENDENCY INJECTION OF MAPPING
            services.AddMappings();

            return services;
        }
    }

}