using System.ComponentModel.DataAnnotations;

namespace EKART.CustomValidation
{
    public class ValidUnitPriceAttribute : ValidationAttribute
    {
        public ValidUnitPriceAttribute() : base("Unit price must be positive value or null")
        {

        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }
            if(value is decimal unitPrice)
            {
                return unitPrice >= 0;
            }

            return false;
        }
    }
}
