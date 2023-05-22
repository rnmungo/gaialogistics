namespace UI.GaiaLogistics.ViewModels
{
    public class BranchCreateRequestViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string BranchType { get; set; }
        public Guid CityId { get; set; }
    }
}
