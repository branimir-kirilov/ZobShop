using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.Details;
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
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDetailsViewModel> Select()
        {
            return this.Model.Products;
        }

        public void Update(int id)
        {
            var item = this.Model.Products.FirstOrDefault(p => p.Id == id);

            if (item != null)
            {
                TryUpdateModel(item);
            }
        }
    }
}