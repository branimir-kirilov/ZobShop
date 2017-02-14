using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Administration.EditProduct
{
    public class EditProductPresenter : Presenter<IEditProductView>
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IViewModelFactory factory;

        public EditProductPresenter(IEditProductView view,
            IProductService productService,
            IViewModelFactory factory,
            ICategoryService categoryService) : base(view)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
            this.View.ProductEdit += View_ProductEdit;
        }

        private void View_ProductEdit(object sender, EditProductEventArgs e)
        {
            var product = this.productService.GetById(e.ProductId);

            product = this.SetupChanges(product, e);

            this.productService.EditProduct(product);
        }

        private Models.Product SetupChanges(Models.Product product, EditProductEventArgs args)
        {
            if (!product.Category.Name.Equals(args.Category))
            {
                var category = this.categoryService.GetCategoryByName(args.Category) ??
                               this.categoryService.CreateCategory(args.Category);

                product.Category = category;
            }

            if (args.Name != null)
            {
                product.Name = args.Name;
            }

            if (args.ImageBuffer != null)
            {
                product.ImageBuffer = args.ImageBuffer;
            }

            if (args.ImageMimeType != null)
            {
                product.ImageMimeType = args.ImageMimeType;
            }

            if (args.Maker != null)
            {
                product.Maker = args.Maker;
            }

            if (args.Price != null)
            {
                product.Price = args.Price.Value;
            }

            if (args.Volume != null)
            {
                product.Volume = args.Volume.Value;
            }

            return product;
        }

        private void View_MyInit(object sender, ProductDetailsEventArgs e)
        {
            var product = this.productService.GetById(e.Id);

            var viewModel = this.factory.CreateProductDetailsViewModel(product.Name,
               product.Category.Name,
               product.Price,
               product.Volume,
               product.Maker,
               product.ImageMimeType,
               product.ImageBuffer);

            this.View.Model = viewModel;
        }
    }
}
