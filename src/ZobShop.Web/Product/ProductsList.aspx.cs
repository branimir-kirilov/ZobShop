using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.List;

namespace ZobShop.Web.Product
{
    [PresenterBinding(typeof(ProductListPresenter))]
    public partial class ProductsList : MvpPage<ProductListViewModel>, IProductListView
    {
        public event EventHandler<ProductListEventArgs> MyInit;
        public event EventHandler<ProductListEventArgs> CategoryChanged;

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var args = new ProductListEventArgs(null);
            this.MyInit?.Invoke(this, args);
        }

        protected void CategoriesDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var category = this.CategoriesDropDownList.SelectedValue;
            if (this.CategoriesDropDownList.SelectedIndex == 1)
            {
                category = null;
            }

            var args = new ProductListEventArgs(category);
            this.CategoryChanged?.Invoke(this, args);
        }

        public IEnumerable<ProductDetailsViewModel> Select()
        {
            return this.Model.Products;
        }

        public IEnumerable<string> SelectCategories()
        {
            return this.Model.Categories;
        }
    }
}