using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.Details.RateProduct;

namespace ZobShop.ModelViewPresenter.Product.Details
{
    public interface IProductDetailsView : IView<ProductDetailsViewModel>
    {
        event EventHandler<ProductDetailsEventArgs> MyProductDetails;

        event EventHandler<RateProductEventArgs> RateProduct;
    }
}
