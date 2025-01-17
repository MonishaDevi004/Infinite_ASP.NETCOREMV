using System.ComponentModel.DataAnnotations;

namespace EKART.Models
{
    public class Ten_Most_Expensive_Products
    {
        [Key]
        public string TenMostExpensiveProducts { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
