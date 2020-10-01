using AutoMapper;
using Shops.Web.Api.Models;

namespace Shops.Web.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Shop, ShopRequest>().ReverseMap();
            CreateMap<Shop, ShopResponse>().ReverseMap();
        }
    }
}
