using System.Linq;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.List
{
    public class ProductListPresenter : Presenter<IProductListView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;

        public ProductListPresenter(IProductListView view, IProductService service, IViewModelFactory factory) : base(view)
        {
            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, ProductListEventArgs e)
        {
            var category = e.Category;

            if (category == null)
            {
                this.View.Model.Products = this.service.GetProducts()
                    .Select(p => this.factory.CreateProductDetailsViewModel(p.Name,
                    p.Category.Name,
                    p.Price,
                    p.Volume,
                    p.Maker,
                    p.ImageMimeType,
                    p.ImageBuffer));
            }
            else
            {
                this.View.Model.Products = this.service.GetProductsByCategory(category)
                    .Select(p => this.factory.CreateProductDetailsViewModel(p.Name,
                    p.Category.Name,
                    p.Price,
                    p.Volume,
                    p.Maker,
                    p.ImageMimeType,
                    p.ImageBuffer));
            }
        }
    }
}
