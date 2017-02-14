using System;

namespace ZobShop.ModelViewPresenter.Administration.EditProduct
{
    public class EditProductEventArgs : EventArgs
    {
        public EditProductEventArgs(int id,
            string name = null,
            string category = null,
            decimal? price = null,
            double? volume = null,
            string maker = null,
            string imageMimeType = null,
            byte[] imageBuffer = null)
        {
            this.ProductId = id;
            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Volume = volume;
            this.Maker = maker;
            this.ImageMimeType = imageMimeType;
            this.ImageBuffer = imageBuffer;
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal? Price { get; set; }

        public double? Volume { get; set; }

        public string Maker { get; set; }

        public string ImageMimeType { get; set; }

        public byte[] ImageBuffer { get; set; }
    }
}
