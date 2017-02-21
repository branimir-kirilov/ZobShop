using System;
using WebFormsMvp;
using ZobShop.Authentication;
using ZobShop.Orders.Contracts;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Checkout
{
    public class CheckoutPresenter : Presenter<ICheckoutView>
    {
        private readonly IAuthenticationProvider provider;
        private readonly IUserService service;
        private readonly IViewModelFactory factory;
        private readonly IShoppingCart cart;

        public CheckoutPresenter(ICheckoutView view,
            IAuthenticationProvider provider,
            IUserService service,
            IViewModelFactory factory,
            IShoppingCart cart)
            : base(view)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider cannot be null");
            }

            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.service = service;
            this.provider = provider;
            this.factory = factory;
            this.cart = cart;

            this.View.MyInit += this.View_MyInit;
            this.View.MyCheckout += this.View_MyCheckout;
        }

        private void View_MyCheckout(object sender, CheckoutEventArgs e)
        {
            this.cart.FinishOrder(e.Name, e.Address, e.PhoneNumber);
            this.View.Model.IsCheckoutSuccessful = true;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            var currentUserId = this.provider.CurrentUserId;

            if (currentUserId != null)
            {
                var user = this.service.GetById(currentUserId);
                if (user != null)
                {
                    var model = this.factory.CreateCheckoutViewModel(user.Name, user.Address, user.PhoneNumber);

                    this.View.Model = model;
                }
            }
        }
    }
}
