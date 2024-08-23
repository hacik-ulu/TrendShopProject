using AutoMapper;
using TrendShop.Catalog.Dtos.CategoryDtos;
using TrendShop.Catalog.Dtos.ProductDetailDtos;
using TrendShop.Catalog.Dtos.ProductDetails;
using TrendShop.Catalog.Dtos.ProductDtos;
using TrendShop.Catalog.Dtos.ProductImageDtos;
using TrendShop.Catalog.Entities;

namespace TrendShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        // It will map all entities properties with their Dto's.
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<Product, ResultsProductsWithCategoryDto>().ReverseMap();


        }
    }
}
