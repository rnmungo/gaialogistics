using UI.GaiaLogistics.Validators;

namespace UI.GaiaLogistics.ViewModels
{
    public class BranchFiltersRequestViewModel
    {
        [BranchTypeValidation]
        public string BranchType { get; set; } = string.Empty;
    }
}
