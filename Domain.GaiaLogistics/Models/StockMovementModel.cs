namespace Domain.GaiaLogistics.Models
{
    public class StockMovementModel : BaseEntity
    {
        public string CauseType { get; set; } = string.Empty;
        public Guid BranchOriginId { get; set; } = Guid.Empty;
        public Guid BranchDestinationId { get; set; } = Guid.Empty;
        public Guid UserId { get; set; } = Guid.Empty;

        public virtual BranchModel BranchOrigin { get; set; } = null!;
        public virtual BranchModel BranchDestination { get; set; } = null!;
        public virtual UserModel User { get; set; } = null!;
        public virtual ICollection<StockMovementItemModel> StockMovementItems { get; set;} = new HashSet<StockMovementItemModel>();
    }
}
