using System.Collections.Generic;

namespace Project_2.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string? Phone { get; set; }

        // 🔗 Navigation Property (One Supplier → Many Products)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
