using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.Details
{
    public class ProductDetailsPresenter : Presenter<IProductDetailsView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;

        public ProductDetailsPresenter(IProductDetailsView view, IProductService service, IViewModelFactory factory) : base(view)
        {
            this.service = service;
            this.factory = factory;

            this.View.MyProductDetails += View_MyProductDetails;
        }

        public void View_MyProductDetails(object sender, ProductDetailsEventArgs e)
        {
            var id = e.Id;

            var product = this.service.GetById(id);

            var viewModel = this.factory.CreateProductDetailsViewModel(product.Name,
                product.Category.Name,
                product.Price,
                product.Volume,
                product.Maker);

            this.View.Model = viewModel;
        }
    }
}
