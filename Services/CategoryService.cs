
using AutoMapper;
using Project_2.DTOs.CategoryDTOs;
using Project_2.Helpers;
using Project_2.Models;
using Project_2.Repositories.UnitOfWork;

namespace Project_2.Services
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 🟢 Get All
        public async Task<PagedResponse<CategoryResponseDto>> GetAllAsync(CategoryFilterDto filter)
        {
            var (data, totalCount) = await _unitOfWork.Categories.GetFilteredAsync(filter);
            var Mapped = _mapper.Map<IEnumerable<CategoryResponseDto>>(data);

            return new PagedResponse<CategoryResponseDto>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize),
                Data = Mapped
            };
        }

        // 🟢 Get By Id
        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                return null;

            return _mapper.Map<CategoryResponseDto>(category);
        }

        // 🟢 Create
        public async Task<CategoryResponseDto?> CreateAsync(CreateCategoryDto dto)
        {
            // 💣 check unique name
            var existing = (await _unitOfWork.Categories.GetAllAsync())
                .FirstOrDefault(c => c.Name.ToLower() == dto.Name.ToLower());

            if (existing != null)
                return null;

            var category = _mapper.Map<Category>(dto);

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryResponseDto>(category);
        }

        // 🟢 Update
        public async Task<bool> UpdateAsync(UpdateCategoryDto dto)
        {
            var existing = await _unitOfWork.Categories.GetByIdAsync(dto.Id);

            if (existing == null)
                return false;

            // 💣 check unique name
            var duplicate = (await _unitOfWork.Categories.GetAllAsync())
                .FirstOrDefault(c => c.Name.ToLower() == dto.Name.ToLower() && c.Id != dto.Id);

            if (duplicate != null)
                return false;

            _mapper.Map(dto, existing);

            _unitOfWork.Categories.Update(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // 🟢 Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category == null)
                return false;

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}

