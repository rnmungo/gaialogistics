using BLL.GaiaLogistics.Constants;
using System.ComponentModel.DataAnnotations;

namespace UI.GaiaLogistics.Validators
{
    public class DepositFilterValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string depositFilter = value as string;

            if (depositFilter != Filters.UnionFilter && depositFilter != Filters.FullFilter)
            {
                return new ValidationResult($"El valor del parámetro depositFilter debe ser '{Filters.UnionFilter}' o '{Filters.FullFilter}'");
            }

            return ValidationResult.Success;
        }
    }
}
