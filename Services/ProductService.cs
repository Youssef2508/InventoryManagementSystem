
using AutoMapper;
using Project_2.DTOs.ProductDTOs;
using Project_2.Helpers;
using Project_2.Models;
using Project_2.Repositories.UnitOfWork;


namespace Project_2.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 🟢 Get All with Filtering
        public async Task<PagedResponse<ProductResponseDto>> GetAllAsync(ProductFilterDto filter)
        { 
            var (data, totalCount) = await _unitOfWork.Products.GetFilteredAsync(filter);
            var mapped = _mapper.Map<IEnumerable<ProductResponseDto>>(data);
            return new PagedResponse<ProductResponseDto>
            { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize),
                Data = mapped
            };
        }

        // 🟢 Get By Id
        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductResponseDto>(product);
        }

        // 🟢 Create
        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductResponseDto>(product);
        }

        // 🟢 Update
        public async Task<bool> UpdateAsync(UpdateProductDto dto)
        {
            var existing = await _unitOfWork.Products.GetByIdAsync(dto.Id);

            if (existing == null)
                return false;

            _mapper.Map(dto, existing);

            _unitOfWork.Products.Update(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // 🟢 Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
                return false;

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

