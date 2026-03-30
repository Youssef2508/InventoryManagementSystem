using AutoMapper;
using Project_2.DTOs.SupplierDTOs;
using Project_2.Models;

namespace Project_2.Helpers.Mapping
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, Supplier>();
            CreateMap<Supplier, SupplierResponseDto>();
        }
    }
}
