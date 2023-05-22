namespace UI.GaiaLogistics.ViewModels
{
    public class StockMovementItemPagedResponseViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public ProductPagedResponseViewModel Product { get; set; }

    }
}
