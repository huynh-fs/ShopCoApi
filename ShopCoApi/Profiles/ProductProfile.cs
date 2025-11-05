using AutoMapper;
using ShopCoApi.Dtos.Product;
using ShopCoApi.Models;

namespace ShopCoApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // Ánh xạ từ Product sang ProductListItemDto
            CreateMap<Product, ProductListItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.PrimaryImageUrl, opt => opt.MapFrom(src =>
                    src.Images.FirstOrDefault(i => i.IsPrimary).Url));

            // Ánh xạ từ Product sang ProductDetailDto
            CreateMap<Product, ProductDetailDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ParentCategoryName, opt => opt.MapFrom(src => src.Category.ParentCategory.Name));

            // Ánh xạ cho các DTO con
            CreateMap<ProductImage, ImageDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ProductVariant, VariantDto>()
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
                .ForMember(dest => dest.ColorHexCode, opt => opt.MapFrom(src => src.Color.HexCode))
                .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name));
        }
    }
}