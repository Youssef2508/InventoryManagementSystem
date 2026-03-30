using Project_2.DTOs.SupplierDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.SupplierRepositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<(IEnumerable<Supplier> Data, int TotalCount)> GetFilteredAsync(SupplierFilterDto filter);
    }
}
