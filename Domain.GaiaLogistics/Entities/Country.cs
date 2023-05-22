namespace Domain.GaiaLogistics.Entities
{
    public class Country : BaseEntity
    {
        public int AreaCode { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Province> Provinces { get; set; } = new List<Province>();
    }
}
