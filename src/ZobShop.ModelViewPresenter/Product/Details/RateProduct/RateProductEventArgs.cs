using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Product.Details.RateProduct
{
    public class RateProductEventArgs : EventArgs
    {
        public RateProductEventArgs(int rating, string content, int productId)
        {
            this.Rating = rating;
            this.Content = content;
            this.ProductId = productId;
        }

        public int Rating { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }
    }
}
