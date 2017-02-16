using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Account;

namespace ZobShop.ModelViewPresenter.Product.Create
{
    public interface ICreateProductView : IView<CreateProductViewModel>
    {
        event EventHandler<CreateProductEventArgs> MyCreateProduct;
    }
}
