using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.ShoppingCart.Add;

namespace ZobShop.Web.ShoppingCart
{
    [PresenterBinding(typeof(AddToCartPresenter))]
    public partial class AddToCart : MvpPage<AddToCartViewModel>, IAddToCartView
    {
        private int id;
        private int quantity;

        public event EventHandler<AddToCartEventArgs> MyAddToCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                id = int.Parse(this.Request.QueryString["id"]);
                quantity = int.Parse(this.Request.QueryString["quantity"]);
            }
            catch (Exception)
            {
                this.ErrorMessages.Text = "Please provide valid arguments";
                return;
            }

            var args = new AddToCartEventArgs(this.id, this.quantity);

            this.MyAddToCart?.Invoke(this, args);

            this.Response.Redirect("Summary");
        }
    }
}