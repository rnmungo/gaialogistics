using BLL.GaiaLogistics.Constants;
using UI.GaiaLogistics.Validators;

namespace UI.GaiaLogistics.ViewModels
{
    public class StockMovementFiltersRequestViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public int SizeLimit { get; set; } = 10;
        public DateTime From { get; set; } = DateTime.Now;
        public DateTime To { get; set; } = DateTime.Now;
        public string OriginId { get; set; } = string.Empty;
        public string DestinationId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        [CauseTypeValidation]
        public string CauseType { get; set; } = string.Empty;

        [DepositFilterValidation]
        public string DepositFilter { get; set; } = Filters.UnionFilter;
    }
}
