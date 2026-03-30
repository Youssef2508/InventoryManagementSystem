using AutoMapper;
using Project_2.DTOs.ProductDTOs;
using Project_2.Models;

namespace Project_2.Helpers.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // 🔄 Create
            CreateMap<CreateProductDto, Product>();
            
            // 🔄 Update
            CreateMap<UpdateProductDto, Product>();
            
            // 🔄 Response
            CreateMap<Product, ProductResponseDto>() 
                .ForMember(dest => dest.CategoryName, 
                    opt => opt.MapFrom(src => src.Category.Name)) 
                .ForMember(dest => dest.SupplierName, 
                    opt => opt.MapFrom(src => src.Supplier.Name)); 
        }
    }
}
