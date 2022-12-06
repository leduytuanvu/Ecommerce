using Ecommerce.Contracts.Image.Request;
using Ecommerce.Contracts.Image.Response;
using Ecommerce.Domain.Entities;
using Mapster;

namespace Ecommerce.API.Mapping
{
    public class ImageMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Image, ImageCreateRequest>();
            config.NewConfig<Image, ImageUpdateRequest>();
            config.NewConfig<Image, ImageResponse>();
        }
    }
}
