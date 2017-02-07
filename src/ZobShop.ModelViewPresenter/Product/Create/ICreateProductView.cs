using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Product.Create
{
    public interface ICreateProductView : IView<CreateProductViewModel>
    {
        event EventHandler<CreateProductEventArgs> MyCreateProduct;
    }
}
