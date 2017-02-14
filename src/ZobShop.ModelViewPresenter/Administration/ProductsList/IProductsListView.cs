using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.List;

namespace ZobShop.ModelViewPresenter.Administration.ProductsList
{
    public interface IProductsListView : IView<ProductListViewModel>
    {
        event EventHandler MyInit;

        event EventHandler<EditProductEventArgs> ProductEdit;
    }
}
