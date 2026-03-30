namespace Project_2.DTOs.SupplierDTOs
{
    public class CreateSupplierDto
    {
        public string Name { get; set; } = null!;
        public string ContactEmail { get; set; } = null!; 
        public string? Phone { get; set; }
    }
}
