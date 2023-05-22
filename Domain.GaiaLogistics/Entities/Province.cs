namespace Domain.GaiaLogistics.Entities
{
    public class Province : BaseEntity
    {
        public int? AreaCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }

        public Country Country { get; set; } = null!;
        public List<City> Cities { get; set; } = new List<City>();
    }
}
