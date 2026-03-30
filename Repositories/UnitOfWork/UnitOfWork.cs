using Project_2.Data;
using Project_2.Repositories.CategoryRepositories;
using Project_2.Repositories.ProductRepositories;
using Project_2.Repositories.SupplierRepositories;

namespace Project_2.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context; public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public ISupplierRepository Suppliers { get; }
        public UnitOfWork(
            AppDbContext context,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            ISupplierRepository supplierRepository) 
        { 
            _context = context; 
            Products = productRepository;
            Categories = categoryRepository;
            Suppliers = supplierRepository; 
        }
        public async Task<int> SaveChangesAsync()
        { 
            return await _context.SaveChangesAsync(); 
        }
    }
}
