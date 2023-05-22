namespace Domain.GaiaLogistics.Entities
{
    public class StockMovementItem : BaseEntity
    {
        public int Quantity { get; set; } = 0;
        public Guid ProductId { get; set; } = Guid.Empty;
        public Guid StockMovementId { get; set; }

        public Product Product { get; set; } = null!;
        public StockMovement StockMovement { get; set; } = null!;
    }
}
