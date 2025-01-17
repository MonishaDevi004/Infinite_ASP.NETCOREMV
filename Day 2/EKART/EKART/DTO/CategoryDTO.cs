using System.ComponentModel.DataAnnotations;

namespace EKART.DTO
{
   
    public class CategoryDTO
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

    }
}
