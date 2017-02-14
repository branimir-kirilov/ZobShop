using System;

namespace ZobShop.ModelViewPresenter.Product.Details.RateProduct
{
    public class RateProductEventArgs : EventArgs
    {
        public RateProductEventArgs(int rating, string content, int productId, string authorId)
        {
            this.Rating = rating;
            this.Content = content;
            this.ProductId = productId;
            this.AuthorId = authorId;
        }

        public int Rating { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }

        public string AuthorId { get; set; }
    }
}
