using System;
using System.Collections.ObjectModel;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(ProductDetailsPresenter))]
    public partial class ProductDetails : MvpPage<ProductDetailsViewModel>, IProductDetailsView
    {
        public event EventHandler<ProductDetailsEventArgs> MyProductDetails;

        private const string QueryId = "id";

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = int.Parse(this.Request.QueryString[QueryId]);

            var args = new ProductDetailsEventArgs(id);

            this.MyProductDetails?.Invoke(this, args);
            
            // TODO: Bind to model
        }
    }
}