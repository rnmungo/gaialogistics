using System.Collections.Generic;

namespace Domain.GaiaLogistics.Models
{
    public class ProvinceModel : BaseEntity
    {
        public int? AreaCode { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }

        public virtual CountryModel Country { get; set; } = null!;
        public virtual ICollection<CityModel> Cities { get; set; } = new HashSet<CityModel>();
    }
}
