namespace Project_2.DTOs.CategoryDTOs
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
