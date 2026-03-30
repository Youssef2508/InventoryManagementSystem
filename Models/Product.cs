using System;

namespace Project_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // 🔗 Foreign Keys
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        // 🔗 Navigation Properties
        public Category Category { get; set; } = null!;
        public Supplier Supplier { get; set; } = null!;
    }
}
