using NUnit.Framework;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;

namespace ZobShop.Mvp.Tests.VIewModels.CartLineVIewModelTests
{
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestGetProductId_ShouldReturnCorrectly(int productId)
        {
            var productViewModel = new ProductDetailsViewModel { Id = productId };

            var viewModel = new CartLineViewModel(productViewModel, 0);

            Assert.AreEqual(productId, viewModel.ProductId);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestGetQuantity_ShouldReturnCorrectly(int quantity)
        {
            var productViewModel = new ProductDetailsViewModel();

            var viewModel = new CartLineViewModel(productViewModel, quantity);

            Assert.AreEqual(quantity, viewModel.Quantity);
        }
    }
}
