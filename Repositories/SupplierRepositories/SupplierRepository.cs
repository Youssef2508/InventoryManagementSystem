using Microsoft.EntityFrameworkCore;
using Project_2.Data;
using Project_2.DTOs.SupplierDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.SupplierRepositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context) 
        {
        }

        public async Task<(IEnumerable<Supplier> Data, int TotalCount)> GetFilteredAsync(SupplierFilterDto filter)
        {
            IQueryable<Supplier> query = _context.Suppliers;
            if(!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(s => s.Name.Contains(filter.Name));
            }
            if(!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => s.ContactEmail.Contains(filter.Email));
            }
            var totalCount = await query.CountAsync();
            var data = await query
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ToListAsync();
            return (data, totalCount);
        }
    }
}
