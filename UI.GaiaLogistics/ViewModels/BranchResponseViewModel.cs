namespace UI.GaiaLogistics.ViewModels
{
    public class BranchResponseViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string BranchType { get; set; }
    }
}
