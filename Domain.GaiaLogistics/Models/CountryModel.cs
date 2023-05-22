namespace Domain.GaiaLogistics.Models
{
    public class CountryModel : BaseEntity
    {
        public int AreaCode { get; set; } = 0;
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ProvinceModel> Provinces { get; set; } = new HashSet<ProvinceModel>();
    }
}
