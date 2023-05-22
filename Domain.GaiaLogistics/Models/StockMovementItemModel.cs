namespace Domain.GaiaLogistics.Models
{
    public class StockMovementItemModel : BaseEntity
    {
        public int Quantity { get; set; } = 0;
        public Guid ProductId { get; set; } = Guid.Empty;
        public Guid StockMovementId { get; set; }

        public virtual ProductModel Product { get; set; } = null!;
        public virtual StockMovementModel StockMovement { get; set; } = null!;
    }
}
