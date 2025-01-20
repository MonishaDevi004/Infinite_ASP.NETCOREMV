using EKART.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace EKART.DTO
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Product Name is Required")]
        [StringLength(50)]
        public string ProductName { get; set; } = null!;


        [Required(ErrorMessage = "SupplierName is Required")]
        [Display(Name ="Supplier Name")]
        public int? SupplierId { get; set; }


        [Required(ErrorMessage = " Category Name is Required")]
        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }
        [Required]
        public string? QuantityPerUnit { get; set; }
      
        [ValidUnitPrice]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
