
using AutoMapper;
using Ecommerce.Contracts.Authentication.Response;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Contracts.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginResponse>().ReverseMap();
            CreateMap<User, RegisterResponse>().ReverseMap();
        }
    }
}
