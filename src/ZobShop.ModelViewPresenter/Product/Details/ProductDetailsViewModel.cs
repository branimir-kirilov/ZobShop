namespace ZobShop.ModelViewPresenter.Product.Details
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel()
        {

        }

        public ProductDetailsViewModel(int id, string name, string category, decimal price, double volume, string maker, string imageMimeType, byte[] imageBuffer)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Volume = volume;
            this.Maker = maker;
            this.ImageMimeType = imageMimeType;
            this.ImageBuffer = imageBuffer;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public double Volume { get; set; }

        public string Maker { get; set; }

        public string ImageMimeType { get; set; }

        public byte[] ImageBuffer { get; set; }
    }
}
