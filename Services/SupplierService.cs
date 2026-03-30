using AutoMapper;
using Project_2.DTOs.SupplierDTOs;
using Project_2.Helpers;
using Project_2.Models;
using Project_2.Repositories.UnitOfWork;


namespace Project_2.Services
{
    public class SupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 🟢 Get All
        public async Task<PagedResponse<SupplierResponseDto>> GetAllAsync(SupplierFilterDto filter)
        {
            var (data, totalCount) = await _unitOfWork.Suppliers.GetFilteredAsync(filter);
            var mapped = _mapper.Map<IEnumerable<SupplierResponseDto>>(data);
            return new PagedResponse<SupplierResponseDto>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)filter.PageSize),
                Data = mapped
            };
        }

        // 🟢 Get By Id
        public async Task<SupplierResponseDto?> GetByIdAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                return null;

            return _mapper.Map<SupplierResponseDto>(supplier);
        }

        // 🟢 Create
        public async Task<SupplierResponseDto?> CreateAsync(CreateSupplierDto dto)
        {
            // 💣 optional: check duplicate email
            var existing = (await _unitOfWork.Suppliers.GetAllAsync())
                .FirstOrDefault(s => s.ContactEmail.ToLower() == dto.ContactEmail.ToLower());

            if (existing != null)
                return null;

            var supplier = _mapper.Map<Supplier>(dto);

            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SupplierResponseDto>(supplier);
        }

        // 🟢 Update
        public async Task<bool> UpdateAsync(UpdateSupplierDto dto)
        {
            var existing = await _unitOfWork.Suppliers.GetByIdAsync(dto.Id);

            if (existing == null)
                return false;

            // 💣 check duplicate email
            var duplicate = (await _unitOfWork.Suppliers.GetAllAsync())
                .FirstOrDefault(s => s.ContactEmail.ToLower() == dto.ContactEmail.ToLower() && s.Id != dto.Id);

            if (duplicate != null)
                return false;

            _mapper.Map(dto, existing);

            _unitOfWork.Suppliers.Update(existing);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // 🟢 Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);

            if (supplier == null)
                return false;

            _unitOfWork.Suppliers.Delete(supplier);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
