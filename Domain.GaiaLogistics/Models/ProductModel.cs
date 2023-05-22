namespace Domain.GaiaLogistics.Models
{
    public class ProductModel : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0m;

        public virtual ICollection<StockMovementItemModel> StockMovementItems { get; set; } = new HashSet<StockMovementItemModel>();
    }
}
