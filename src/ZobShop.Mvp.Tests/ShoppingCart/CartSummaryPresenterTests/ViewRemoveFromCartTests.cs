using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;
using ZobShop.Orders.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.CartSummaryPresenterTests
{
    [TestFixture]
    public class ViewRemoveFromCartTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestViewRemoveFromCart_ShouldCallCartRemoveItem(int id)
        {
            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            var args = new DeleteProductEventArgs(id);
            mockedView.Raise(v => v.RemoveFromCart += null, args);

            mockedShoppingCart.Verify(c => c.RemoveItem(id), Times.Once);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestViewRemoveFromCart_ShouldCallCartComputeTotal(int id)
        {
            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            var args = new DeleteProductEventArgs(id);
            mockedView.Raise(v => v.RemoveFromCart += null, args);

            mockedShoppingCart.Verify(c => c.ComputeTotal(), Times.Once);
        }


        [TestCase(1, 12)]
        [TestCase(12, 43.99)]
        public void TestViewRemoveFromCart_ShouldSetViewModelCorrectly(int id, decimal total)
        {
            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedShoppingCart = new Mock<IShoppingCart>();
            mockedShoppingCart.Setup(c => c.ComputeTotal()).Returns(total);

            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            var args = new DeleteProductEventArgs(id);
            mockedView.Raise(v => v.RemoveFromCart += null, args);

            mockedShoppingCart.Verify(c => c.ComputeTotal(), Times.Once);

            Assert.AreEqual(total, mockedView.Object.Model.Total);
        }
    }
}
