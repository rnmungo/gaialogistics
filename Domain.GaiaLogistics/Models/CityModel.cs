namespace Domain.GaiaLogistics.Models
{
    public class CityModel : BaseEntity
    {
        public int? AreaCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ProvinceId { get; set; }

        public virtual ProvinceModel Province { get; set; } = null!;
        public virtual ICollection<BranchModel> Branches { get; set; } = new HashSet<BranchModel>();
    }
}
