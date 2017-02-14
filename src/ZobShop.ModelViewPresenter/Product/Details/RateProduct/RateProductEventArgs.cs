using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Product.Details.RateProduct
{
    public class RateProductEventArgs : EventArgs
    {
        public RateProductEventArgs(int rating, string content, int productId, HttpContext context)
        {
            this.Rating = rating;
            this.Content = content;
            this.ProductId = productId;
            this.Context = context;
        }

        public int Rating { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }

        public HttpContext Context { get; set; }
    }
}
