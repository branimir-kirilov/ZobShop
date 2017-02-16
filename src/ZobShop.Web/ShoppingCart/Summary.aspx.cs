using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;

namespace ZobShop.Web.ShoppingCart
{
    [PresenterBinding(typeof(CartSummaryPresenter))]
    public partial class Summary : MvpPage<CartSummaryVIewModel>, ICartSummaryView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(this, null);
        }

        public IEnumerable<CartLineViewModel> Select()
        {
            return this.Model.Products;
        }

        public event EventHandler MyInit;

        public void Delete(int productId)
        {
        }
    }
}