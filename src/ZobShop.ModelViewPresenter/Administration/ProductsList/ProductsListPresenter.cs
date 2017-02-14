using System;
using System.Linq;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Administration.ProductsList
{
    public class ProductsListPresenter : Presenter<IProductsListView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;

        public ProductsListPresenter(IProductsListView view, IProductService service, IViewModelFactory factory) : base(view)
        {
            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            var products = this.service.GetProducts();

            this.View.Model.Products = products
                .Select(p =>
                this.factory.CreateProductDetailsViewModel(p.Name, p.Category.Name, p.Price, p.Volume, p.Maker, p.ImageMimeType, p.ImageBuffer));
        }
    }
}
