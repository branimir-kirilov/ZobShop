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

        public event EventHandler<CheckoutEventArgs> MyCheckout;

        protected void Checkout_OnClick(object sender, EventArgs e)
        {
            var name = this.Name.Text;
            var address = this.Address.Text;
            var phone = this.Phone.Text;

            var args = new CheckoutEventArgs(name, address, phone);
            this.MyCheckout?.Invoke(this, args);

            if (this.Model.IsCheckoutSuccessful)
            {
                this.Response.Redirect("~/ShoppingCart/OrderFinished");
            }
            else
            {
                this.ErrorMessage.Text = "Something went wrong, please try again";
            }
        }
    }
}