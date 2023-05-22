using Domain.GaiaLogistics.Contracts;

namespace Domain.GaiaLogistics
{
    public abstract class BaseEntity : IBaseEntity, ISoftDeleteEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}