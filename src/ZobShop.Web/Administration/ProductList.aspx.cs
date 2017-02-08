using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.List;

namespace ZobShop.Web.Administration
{
    [PresenterBinding(typeof(ProductsListPresenter))]
    public partial class ProductList : MvpPage<ProductListViewModel>, IProductsListView
    {
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);

            this.Products.DataSource = this.Model.Products;
            this.DataBind();
        }
    }
}