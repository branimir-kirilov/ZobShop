namespace ZobShop.ModelViewPresenter.Product.Details
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel()
        {

        }

        public ProductDetailsViewModel(string name, string category, decimal price, double volume, string maker)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Volume = volume;
            this.Maker = maker;
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public double Volume { get; set; }

        public string Maker { get; set; }
    }
}
