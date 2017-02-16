using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.List;

namespace ZobShop.ModelViewPresenter.Search
{
    public interface ISearchView : IView<ProductListViewModel>
    {
        event EventHandler<SearchEventArgs> MySearch;
    }
}
