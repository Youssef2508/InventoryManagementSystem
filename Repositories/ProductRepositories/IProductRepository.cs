using Project_2.DTOs.ProductDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.ProductRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task <(IEnumerable<Product> Data, int TotalCount)> GetFilteredAsync(ProductFilterDto filter);
    }
}
