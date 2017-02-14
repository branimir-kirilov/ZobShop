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
        public event EventHandler<EditProductEventArgs> ProductEdit;
        public event EventHandler<DeleteProductEventArgs> ProductDelete;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);
        }

        public void Delete(int id)
        {
            var args = new DeleteProductEventArgs(id);

            this.ProductDelete?.Invoke(this, args);
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

                if (ModelState.IsValid)
                {
                    this.ProductEdit?.Invoke(this, new EditProductEventArgs(item));
                }
            }
        }
    }
}