using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter.Administration.EditProduct
{
    public interface IEditProductView : IView<ProductDetailsViewModel>
    {
        event EventHandler<ProductDetailsEventArgs> MyInit;

        event EventHandler<EditProductEventArgs> ProductEdit;
    }
}
