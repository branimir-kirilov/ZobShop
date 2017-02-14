using System;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.EditProduct;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.Web.Administration
{
    public partial class Edit : MvpPage<ProductDetailsViewModel>, IEditProductView
    {
        public event EventHandler<ProductDetailsEventArgs> MyInit;

        public event EventHandler<EditProductEventArgs> ProductEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Add UI

            try
            {
                var id = int.Parse(this.Context.Request.QueryString["id"]);
                var args = new ProductDetailsEventArgs(id);

                this.MyInit?.Invoke(this, args);
            }
            catch (Exception)
            {

            }
        }
    }
}