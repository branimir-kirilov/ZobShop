using System;
using Microsoft.AspNet.Identity;
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
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (productRatingService == null)
            {
                throw new ArgumentNullException("productRatingService cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.service = service;
            this.productRatingService = productRatingService;
            this.factory = factory;

            this.View.MyProductDetails += View_MyProductDetails;
            this.View.RateProduct += View_RateProduct;
        }

        private void View_RateProduct(object sender, RateProductEventArgs e)
        {
            var userId = e.Context.User.Identity.GetUserId();

            this.productRatingService.CreateProductRating(e.Rating, e.Content, e.ProductId, userId);
        }

        public void View_MyProductDetails(object sender, ProductDetailsEventArgs e)
        {
            var id = e.Id;

            var product = this.service.GetById(id);

            var viewModel = this.factory.CreateProductDetailsViewModel(product.ProductId,
                product.Name,
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
