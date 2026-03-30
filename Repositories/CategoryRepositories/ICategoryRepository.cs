using Project_2.DTOs.CategoryDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.CategoryRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<(IEnumerable<Category> Data, int TotalCount)> GetFilteredAsync(CategoryFilterDto filter);
    }
}
