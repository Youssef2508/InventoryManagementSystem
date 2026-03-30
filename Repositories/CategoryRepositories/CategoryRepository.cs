using Microsoft.EntityFrameworkCore;
using Project_2.Data;
using Project_2.DTOs.CategoryDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.CategoryRepositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Category> Data, int TotalCount)> GetFilteredAsync(CategoryFilterDto filter)
        {
            IQueryable<Category> query = _context.Categories;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(c => c.Name.Contains(filter.Name));
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
