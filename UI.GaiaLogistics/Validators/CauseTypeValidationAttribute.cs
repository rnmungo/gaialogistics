using System.ComponentModel.DataAnnotations;
using BLL.GaiaLogistics.Extensions;

namespace UI.GaiaLogistics.Validators
{
    public class CauseTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string causeType = value as string;

            if (causeType.IsNullOrEmpty())
            {
                return ValidationResult.Success;
            }

            if (causeType != "Transfer" && causeType != "Inventory")
            {
                return new ValidationResult("El valor del parámetro causeType debe ser 'Transfer' o 'Inventory'");
            }

            return ValidationResult.Success;
        }
    }
}
