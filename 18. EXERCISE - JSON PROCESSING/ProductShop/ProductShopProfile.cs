using AutoMapper;
using ProductShop.Dto;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<User, SoldProductsDto>()
                .ForMember(x => x.Count, y => y.MapFrom(x => x.ProductsSold.Where(z => z.Buyer != null).Count()))
                .ForMember(x => x.Products, y => y.MapFrom(x => x.ProductsSold.Where(z => z.Buyer != null)));
            CreateMap<User, UserDetailsDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(x => x));
            CreateMap<UserDetailsDto[], UserInfoDto>()
                .ForMember(x => x.UsersCount, y => y.MapFrom(x => x.Length))
                .ForMember(x => x.Users, y => y.MapFrom(x => x));
        }
    }
}
