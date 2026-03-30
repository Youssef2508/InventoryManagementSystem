using Project_2.Repositories.CategoryRepositories;
using Project_2.Repositories.ProductRepositories;
using Project_2.Repositories.SupplierRepositories;

namespace Project_2.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISupplierRepository Suppliers { get; }
        Task<int> SaveChangesAsync();
    }
}
