using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter.ShoppingCart.Add;
using ZobShop.Orders.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.Add.AddPresenterTests
{
    [TestFixture]
    public class ViewMyAddToCartTests
    {
        [TestCase(1, 2)]
        [TestCase(7, 4)]
        [TestCase(13, 21)]
        public void TestViewMyAddToCart_ShouldCallCartItemAddToCartCorrectly(int productId, int quantity)
        {
            var mockedView = new Mock<IAddToCartView>();
            var mockedCart = new Mock<IShoppingCart>();

            var presenter = new AddToCartPresenter(mockedView.Object, mockedCart.Object);

            var args = new AddToCartEventArgs(productId, quantity);

            mockedView.Raise(v => v.MyAddToCart += null, args);

            mockedCart.Verify(c => c.AddItem(productId, quantity), Times.Once);
        }
    }
}
