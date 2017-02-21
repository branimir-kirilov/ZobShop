using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;

namespace ZobShop.Web.ShoppingCart
{
    [PresenterBinding(typeof(CheckoutPresenter))]
    public partial class Checkout : MvpPage<CheckoutViewModel>, ICheckoutView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(this, e);

            this.Address.Text = this.Model.Address;
            this.Name.Text = this.Model.Name;
            this.Phone.Text = this.Model.PhoneNumber;
        }

        public event EventHandler MyInit;
    }
}