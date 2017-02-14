using System;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter.Administration.ProductsList
{
    public class EditProductEventArgs : EventArgs
    {
        public EditProductEventArgs(ProductDetailsViewModel model)
        {
            this.Model = model;
        }

        public ProductDetailsViewModel Model { get; set; }
    }
}
