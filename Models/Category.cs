using System.Collections.Generic;

namespace Project_2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; public string? Description { get; set; }
        // 🔗 Navigation Property (One Category → Many Products)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
