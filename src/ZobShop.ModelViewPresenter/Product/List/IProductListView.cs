using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public interface IProductListView : IView<ProductListViewModel>
    {
        event EventHandler<ProductListEventArgs> MyInit;
    }
}
