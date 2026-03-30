using AutoMapper;
using Project_2.DTOs.CategoryDTOs;
using Project_2.Models;

namespace Project_2.Helpers.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // 🔄 Create
            CreateMap<CreateCategoryDto, Category>();

            // 🔄 Update
            CreateMap<UpdateCategoryDto, Category>();

            // 🔄 Response
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}
