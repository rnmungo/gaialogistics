namespace UI.GaiaLogistics.ViewModels
{
    public class ProductPagedResponseViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
