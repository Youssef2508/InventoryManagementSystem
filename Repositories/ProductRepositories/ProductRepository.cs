using Microsoft.EntityFrameworkCore;
using Project_2.Data;
using Project_2.DTOs.ProductDTOs;
using Project_2.Models;
using Project_2.Repositories.GenericRepositories;

namespace Project_2.Repositories.ProductRepositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) 
        { 
        }
        public async Task<(IEnumerable<Product> Data, int TotalCount)> GetFilteredAsync(ProductFilterDto filter)
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier); 

            // 🔍 Filtering
            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(p => p.Name.Contains(filter.Name)); 
            } 
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            } 
            if (filter.SupplierId.HasValue) 
            {
                query = query.Where(p => p.SupplierId == filter.SupplierId.Value);
            } 
            if (filter.MinPrice.HasValue) 
            {
                query = query.Where(p => p.Price >= filter.MinPrice.Value); 
            }
            if (filter.MaxPrice.HasValue) 
            { 
                query = query.Where(p => p.Price <= filter.MaxPrice.Value); 
            } 
            if (filter.InStock.HasValue) 
            { 
                if (filter.InStock.Value) 
                    query = query.Where(p => p.StockQuantity > 0); 
                else 
                    query = query.Where(p => p.StockQuantity == 0);
            } 

            var totalCount = await query.CountAsync();

            // 🔃 Sorting
            query = filter.SortBy?.ToLower() switch 
            {
                "name" => filter.IsDescending 
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name),
                "price" => filter.IsDescending 
                    ? query.OrderByDescending(p => p.Price) 
                    : query.OrderBy(p => p.Price),
                "stock" => filter.IsDescending 
                    ? query.OrderByDescending(p => p.StockQuantity) 
                    : query.OrderBy(p => p.StockQuantity), 
                
                _ => query.OrderBy(p => p.Id) };

            // 📄 Pagination
            var data = await query
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ToListAsync();

            return (data, totalCount);
        }
    }
}
