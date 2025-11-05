using AutoMapper;
using ShopCoApi.Dtos.Cart;
using ShopCoApi.Models;

namespace ShopCoApi.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<ShoppingCart, CartDto>();

            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductVariant.Product.Name))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.ProductVariant.Color.Name))
                .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.ProductVariant.Size.Name))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.ProductVariant.Price))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                    src.ProductVariant.Product.Images.FirstOrDefault(i => i.IsPrimary) != null
                    ? src.ProductVariant.Product.Images.FirstOrDefault(i => i.IsPrimary).Url
                    : null));
        }
    }
}
