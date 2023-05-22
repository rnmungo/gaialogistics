namespace Domain.GaiaLogistics.Entities
{
    public class City : BaseEntity
    {
        public int? AreaCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ProvinceId { get; set; }

        public Province Province { get; set; } = null!;
        public List<Branch> Branches { get; set; } = new List<Branch>();
    }
}
