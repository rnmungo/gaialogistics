namespace UI.GaiaLogistics.ViewModels
{
    public class BranchPagedResponseViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BranchType { get; set; } = string.Empty;
    }
}
