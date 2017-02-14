using System;
using System.Drawing;
using System.IO;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.List;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(ProductListPresenter))]
    public partial class ProductsList : MvpPage<ProductListViewModel>, IProductListView
    {
        public event EventHandler<ProductListEventArgs> MyInit;

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
  
        protected void Page_Load(object sender, EventArgs e)
        {
            var query = this.Request.QueryString;
            var category = query?["category"];

            var args = new ProductListEventArgs(category);
            this.MyInit?.Invoke(this, args);

            this.ProductList.DataSource = this.Model.Products;
            this.DataBind();
        }
    }
}