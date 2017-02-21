using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;

namespace ZobShop.ModelViewPresenter
{
    public interface IViewModelFactory
    {
        ProductDetailsViewModel CreateProductDetailsViewModel(int id,
            string name,
            string category,
            decimal price,
            double volume,
            string maker,
            string imageMimeType,
            byte[] imageBuffer);

        UserDetailsViewModel CreateUserDetailsViewModel(string email, string address, string phoneNumber,
            string username, string id);

        CartLineViewModel CreateCartLineViewModel(ProductDetailsViewModel model, int quantity);

        CheckoutViewModel CreateCheckoutViewModel(string name, string address, string phoneNumber);
    }
}
