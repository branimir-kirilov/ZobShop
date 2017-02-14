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
        private readonly ICategoryService categoryService;

        public ProductsListPresenter(IProductsListView view, IProductService service, IViewModelFactory factory, ICategoryService categoryService)
            : base(view)
        {
            this.service = service;
            this.factory = factory;
            this.categoryService = categoryService;

            this.View.MyInit += View_MyInit;
            this.View.ProductEdit += View_ProductEdit;
            this.View.ProductDelete += View_ProductDelete;
        }

        private void View_ProductDelete(object sender, DeleteProductEventArgs e)
        {
            var id = e.Id;

            this.service.DeleteProduct(id);
        }

        private void View_ProductEdit(object sender, EditProductEventArgs e)
        {
            var product = this.service.GetById(e.Model.Id);

            product = this.SetupChanges(product, e);

            this.service.EditProduct(product);
        }

        private Models.Product SetupChanges(Models.Product product, EditProductEventArgs args)
        {
            if (!product.Category.Name.Equals(args.Model.Category))
            {
                var category = this.categoryService.GetCategoryByName(args.Model.Category) ??
                               this.categoryService.CreateCategory(args.Model.Category);

                product.Category = category;
            }

            product.Name = args.Model.Name;
            product.ImageBuffer = args.Model.ImageBuffer;
            product.ImageMimeType = args.Model.ImageMimeType;
            product.Maker = args.Model.Maker;
            product.Price = args.Model.Price;
            product.Volume = args.Model.Volume;

            return product;
        }


        private void View_MyInit(object sender, EventArgs e)
        {
            var products = this.service.GetProducts();

            this.View.Model.Products = products
                .Select(p =>
                this.factory.CreateProductDetailsViewModel(p.ProductId, p.Name, p.Category.Name, p.Price, p.Volume, p.Maker, p.ImageMimeType, p.ImageBuffer));
        }
    }
}
