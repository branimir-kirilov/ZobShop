using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter
{
    public interface IViewModelFactory
    {
        ProductDetailsViewModel CreateProductDetailsViewModel(string name, string category, decimal price, double volume, string maker);
    }
}
