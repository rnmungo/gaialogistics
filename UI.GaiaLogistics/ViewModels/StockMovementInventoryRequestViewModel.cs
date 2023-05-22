namespace UI.GaiaLogistics.ViewModels
{
    public class StockMovementInventoryRequestViewModel
    {
        public Guid BranchId { get; set; }
        public Guid UserId { get; set; }

        public List<StockMovementItemRequestViewModel> Items { get; set; }
    }
}
