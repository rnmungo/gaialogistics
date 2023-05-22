namespace UI.GaiaLogistics.ViewModels
{
    public class StockMovementTransferRequestViewModel
    {
        public Guid OriginId { get; set; }
        public Guid DestinationId { get; set; }
        public Guid UserId { get; set; }

        public List<StockMovementItemRequestViewModel> Items { get; set; }
    }
}
