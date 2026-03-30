using Project_2.Helpers;

namespace Project_2.DTOs.SupplierDTOs
{
    public class SupplierFilterDto : Pager
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
