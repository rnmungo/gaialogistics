namespace Domain.GaiaLogistics.Contracts
{
    public interface ISoftDeleteEntity
    {
        public DateTime? DeletedAt { get; set; }
    }
}
