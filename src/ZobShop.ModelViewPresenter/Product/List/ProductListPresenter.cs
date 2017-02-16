using System;
using System.Collections.Generic;
using System.Linq;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public class ProductListPresenter : Presenter<IProductListView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;

        public ProductListPresenter(IProductListView view, IProductService service, IViewModelFactory factory) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
            this.View.CategoryChanged += View_CategoryChanged;
        }

        private void View_CategoryChanged(object sender, ProductListEventArgs e)
        {
            var category = e.Category;

            if (string.IsNullOrEmpty(category))
            {
                return;
            }

            var productsByCategory = this.View.Model.Products
                .Where(p => p.Category.Equals(category));

            this.View.Model.Products = productsByCategory;
        }

        private void View_MyInit(object sender, ProductListEventArgs e)
        {
            var category = e.Category;

            IEnumerable<ProductDetailsViewModel> products;
            if (string.IsNullOrEmpty(category))
            {
                products = this.service.GetProducts()
                     .Select(p => this.factory.CreateProductDetailsViewModel(p.ProductId,
                         p.Name,
                     p.Category.Name,
                     p.Price,
                     p.Volume,
                     p.Maker,
                     p.ImageMimeType,
                     p.ImageBuffer));
            }
            else
            {
                products = this.service.GetProductsByCategory(category)
                    .Select(p => this.factory.CreateProductDetailsViewModel(p.ProductId,
                        p.Name,
                    p.Category.Name,
                    p.Price,
                    p.Volume,
                    p.Maker,
                    p.ImageMimeType,
                    p.ImageBuffer));
            }

            var categories = new List<string> { "Select Category", "All" };
            categories.AddRange(products.Select(p => p.Category).Distinct());
            this.View.Model.Products = products;
            this.View.Model.Categories = categories;
        }
    }
}
