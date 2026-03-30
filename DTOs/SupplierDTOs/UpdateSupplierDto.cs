namespace Project_2.DTOs.SupplierDTOs
{
    public class UpdateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
