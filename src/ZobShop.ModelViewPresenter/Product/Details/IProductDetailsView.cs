using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Product.Details
{
    public interface IProductDetailsView : IView<ProductDetailsViewModel>
    {
        event EventHandler<ProductDetailsEventArgs> MyProductDetails;
    }
}
