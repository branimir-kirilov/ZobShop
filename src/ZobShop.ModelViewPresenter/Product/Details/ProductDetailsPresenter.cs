using WebFormsMvp;
using ZobShop.ModelViewPresenter.Product.Details.RateProduct;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Product.Details
{
    public class ProductDetailsPresenter : Presenter<IProductDetailsView>
    {
        private readonly IProductService service;
        private readonly IViewModelFactory factory;
        private readonly IProductRatingService productRatingService;

        public ProductDetailsPresenter(IProductDetailsView view,
            IProductService service,
            IViewModelFactory factory,
            IProductRatingService productRatingService) : base(view)
        {
            this.service = service;
            this.productRatingService = productRatingService;
            this.factory = factory;

            this.View.MyProductDetails += View_MyProductDetails;
            this.View.RateProduct += View_RateProduct;
        }

        private void View_RateProduct(object sender, RateProductEventArgs e)
        {
            this.productRatingService.CreateProductRating(e.Rating, e.Content, e.ProductId, e.AuthorId);
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
