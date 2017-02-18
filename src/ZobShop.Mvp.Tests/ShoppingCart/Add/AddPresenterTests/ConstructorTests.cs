using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter.ShoppingCart.Add;
using ZobShop.Orders.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.Add.AddPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassIShoppingCartNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IAddToCartView>();

            Assert.Throws<ArgumentNullException>(() => new AddToCartPresenter(mockedView.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<IAddToCartView>();
            var mockedCart = new Mock<IShoppingCart>();

            Assert.DoesNotThrow(() => new AddToCartPresenter(mockedView.Object, mockedCart.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IAddToCartView>();
            var mockedCart = new Mock<IShoppingCart>();

            var presenter = new AddToCartPresenter(mockedView.Object, mockedCart.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
