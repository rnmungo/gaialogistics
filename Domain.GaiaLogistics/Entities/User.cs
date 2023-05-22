namespace Domain.GaiaLogistics.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public List<StockMovement> StockMovement { get; set; } = new List<StockMovement>();
    }
}
