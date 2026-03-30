namespace Project_2.DTOs.ProductDTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; } = null!; 
        public string SupplierName { get; set; } = null!;
    }
}
