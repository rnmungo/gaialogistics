using Domain.GaiaLogistics.Enums;

namespace Domain.GaiaLogistics.Entities
{
    public class Branch : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public BranchTypeEnum BranchType { get; set; }
        public Guid CityId { get; set; }

        public City City { get; set; } = null!;
        public List<StockMovement> OriginStockMovement { get; set; } = new List<StockMovement>();
        public List<StockMovement> DestinationStockMovement { get; set; } = new List<StockMovement>();
    }
}
