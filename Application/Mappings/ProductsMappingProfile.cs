using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class ProductsMappingProfile : Profile
{
    public ProductsMappingProfile()
    {
        // Product Mapping
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }
}