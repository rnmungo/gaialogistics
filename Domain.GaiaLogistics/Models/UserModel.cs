namespace Domain.GaiaLogistics.Models
{
    public class UserModel : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<StockMovementModel> StockMovements { get; set; } = new HashSet<StockMovementModel>();
    }
}
