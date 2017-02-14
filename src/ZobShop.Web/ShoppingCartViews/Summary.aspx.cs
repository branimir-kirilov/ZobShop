using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;

namespace ZobShop.Web.ShoppingCartViews
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
    }
}