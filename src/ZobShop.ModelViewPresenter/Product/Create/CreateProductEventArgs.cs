using System;

namespace ZobShop.ModelViewPresenter.Product.Create
{
    public class CreateProductEventArgs : EventArgs
    {
        public CreateProductEventArgs(string name, string categoryName, int quantity, decimal price, double volume, string maker)
        {
            this.Name = name;
            this.CategoryName = categoryName;
            this.Quantity = quantity;
            this.Price = price;
            this.Volume = volume;
            this.Maker = maker;
        }

        public string CategoryName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public double Volume { get; set; }

        public string Maker { get; set; }

        public string Name { get; set; }

        public string ImageMimeType { get; set; }

        public byte[] ImageBuffer { get; set; }
    }
}
