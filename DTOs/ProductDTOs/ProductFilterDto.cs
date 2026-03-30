using Project_2.Helpers;

namespace Project_2.DTOs.ProductDTOs
{
    public class ProductFilterDto : Pager
    {
        // 🔍 Filtering
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? InStock { get; set; }

        // 🔃 Sorting
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
    }
}
