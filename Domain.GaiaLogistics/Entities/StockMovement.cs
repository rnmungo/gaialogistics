using Domain.GaiaLogistics.Enums;

namespace Domain.GaiaLogistics.Entities
{
    public class StockMovement : BaseEntity
    {
        public CauseTypeEnum CauseType { get; set; }
        public Guid BranchOriginId { get; set; } = Guid.Empty;
        public Guid BranchDestinationId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;

        public Branch BranchOrigin { get; set; } = null!;
        public Branch BranchDestination { get; set; } = null!;
        public User User { get; set; } = null!;
        public List<StockMovementItem> StockMovementItems { get; set; } = new List<StockMovementItem>();
    }
}
