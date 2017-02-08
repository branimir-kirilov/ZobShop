using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter
{
    public interface IViewModelFactory
    {
        ProductDetailsViewModel CreateProductDetailsViewModel(string name, string category, decimal price, double volume, string maker);

        UserDetailsViewModel CreateUserDetailsViewModel(string email, string address, string phoneNumber,
            string username, string id);
    }
}
