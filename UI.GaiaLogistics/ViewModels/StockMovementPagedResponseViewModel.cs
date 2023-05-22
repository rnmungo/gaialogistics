namespace UI.GaiaLogistics.ViewModels
{
    public class StockMovementPagedResponseViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CauseType { get; set; } = string.Empty;
        public UserPagedResponseViewModel User { get; set; }
        public BranchPagedResponseViewModel BranchOrigin { get; set; }
        public BranchPagedResponseViewModel BranchDestination { get; set; }
        public List<StockMovementItemPagedResponseViewModel> StockMovementItems { get; set; } = new List<StockMovementItemPagedResponseViewModel>();
    }
}
