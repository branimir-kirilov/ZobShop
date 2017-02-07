using System;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public class ProductListEventArgs : EventArgs
    {
        public ProductListEventArgs(string category)
        {
            this.Category = category;
        }

        public string Category { get; set; }
    }
}
