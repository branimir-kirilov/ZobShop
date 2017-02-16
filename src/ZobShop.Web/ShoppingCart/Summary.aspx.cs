using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;

namespace ZobShop.Web.ShoppingCart
{
    [PresenterBinding(typeof(CartSummaryPresenter))]
    public partial class Summary : MvpPage<CartSummaryVIewModel>, ICartSummaryView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(this, null);
            this.Total.Text = this.Model.Total.ToString();
        }

        public IEnumerable<CartLineViewModel> Select()
        {
            return this.Model.Products;
        }

        public event EventHandler MyInit;
        public event EventHandler<DeleteProductEventArgs> RemoveFromCart;

        public void Delete(int productId)
        {
            var args = new DeleteProductEventArgs(productId);
            this.RemoveFromCart?.Invoke(this, args);
            this.Total.Text = this.Model.Total.ToString();
        }
    }
}