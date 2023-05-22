namespace Domain.GaiaLogistics.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;

        public List<StockMovementItem> StockMovementItems { get; set; } = new List<StockMovementItem>();
    }
}
