namespace Domain.GaiaLogistics.Models
{
    public class BranchModel : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BranchType { get; set; } = string.Empty;
        public Guid CityId { get; set; }

        public virtual CityModel City { get; set; } = null!;
        public virtual ICollection<StockMovementModel> OriginStockMovements { get; set; } = new HashSet<StockMovementModel>();
        public virtual ICollection<StockMovementModel> DestinationStockMovements { get; set; } = new HashSet<StockMovementModel>();
    }
}
