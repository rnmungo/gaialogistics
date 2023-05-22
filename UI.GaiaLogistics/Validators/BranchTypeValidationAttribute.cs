using System.ComponentModel.DataAnnotations;
using BLL.GaiaLogistics.Extensions;

namespace UI.GaiaLogistics.Validators
{
    public class BranchTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string branchType = value as string;

            if (branchType.IsNullOrEmpty())
            {
                return ValidationResult.Success;
            }

            if (branchType != "Deposit" && branchType != "Store")
            {
                return new ValidationResult("El valor del parámetro branchType debe ser 'Deposit' o 'Store'");
            }

            return ValidationResult.Success;
        }
    }
}
