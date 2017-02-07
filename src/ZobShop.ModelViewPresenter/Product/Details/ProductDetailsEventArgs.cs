using System;

namespace ZobShop.ModelViewPresenter.Product.Details
{
    public class ProductDetailsEventArgs : EventArgs
    {
        public ProductDetailsEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
