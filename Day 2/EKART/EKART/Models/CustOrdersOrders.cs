using System.ComponentModel.DataAnnotations;

namespace EKART.Models
{
    public class CustOrdersOrders
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }
    }
}
