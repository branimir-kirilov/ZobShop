using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;
using ZobShop.Orders.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.CartSummaryPresenterTests
{
    [TestFixture]
    public class VIewMyInitTests
    {
        [Test]
        public void TestViewMyInit_ShouldCallCartCartLines()
        {
            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedShoppingCart = new Mock<IShoppingCart>();
            mockedShoppingCart.Setup(c => c.CartLines).Returns(new List<ICartLine>());
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedShoppingCart.Verify(c => c.CartLines, Times.Once);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg", "Fun Category", 12)]
        [TestCase("TestProductOther", 12, 5.00, 2.00, "TestMaker2", ".png", "Fun Category", 1)]
        public void TestViewMyInit_ShouldSetViewModelProductsCorrectly(string name,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType,
            string categoryName,
            int id)
        {
            var imgBuffer = new byte[3];
            var category = new Category(categoryName);
            var product = new Product(name, category, quantity, price, volume, maker, imageMimeType, imgBuffer);

            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedCartLine = new Mock<ICartLine>();
            mockedCartLine.Setup(c => c.Product).Returns(product);
            mockedCartLine.Setup(c => c.Quantity).Returns(quantity);

            var cartLines = new List<ICartLine> { mockedCartLine.Object };
            var mockedShoppingCart = new Mock<IShoppingCart>();
            mockedShoppingCart.Setup(c => c.CartLines).Returns(cartLines);

            var productDetailsViewModel = new ProductDetailsViewModel { Id = id };

            var cartLineViewModel = new CartLineViewModel(productDetailsViewModel, quantity);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateCartLineViewModel(It.IsAny<ProductDetailsViewModel>(), It.IsAny<int>()))
                .Returns(cartLineViewModel);

            var expectedResult = new List<CartLineViewModel> { cartLineViewModel };

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            CollectionAssert.AreEqual(expectedResult, mockedView.Object.Model.Products);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg", "Fun Category", 12, 35)]
        [TestCase("TestProductOther", 12, 5.00, 2.00, "TestMaker2", ".png", "Fun Category", 1, 99.99)]
        public void TestViewMyInit_ShouldSetViewModelTotalCorrectly(string name,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType,
           string categoryName,
           int id,
           decimal total)
        {
            var imgBuffer = new byte[3];
            var category = new Category(categoryName);
            var product = new Product(name, category, quantity, price, volume, maker, imageMimeType, imgBuffer);

            var mockedView = new Mock<ICartSummaryView>();
            mockedView.Setup(v => v.Model).Returns(new CartSummaryVIewModel());

            var mockedCartLine = new Mock<ICartLine>();
            mockedCartLine.Setup(c => c.Product).Returns(product);
            mockedCartLine.Setup(c => c.Quantity).Returns(quantity);

            var cartLines = new List<ICartLine> { mockedCartLine.Object };

            var mockedShoppingCart = new Mock<IShoppingCart>();
            mockedShoppingCart.Setup(c => c.CartLines).Returns(cartLines);
            mockedShoppingCart.Setup(c => c.ComputeTotal()).Returns(total);

            var productDetailsViewModel = new ProductDetailsViewModel { Id = id };

            var cartLineViewModel = new CartLineViewModel(productDetailsViewModel, quantity);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateCartLineViewModel(It.IsAny<ProductDetailsViewModel>(), It.IsAny<int>()))
                .Returns(cartLineViewModel);

            var expectedResult = new List<CartLineViewModel> { cartLineViewModel };

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            Assert.AreEqual(total, mockedView.Object.Model.Total);
        }
    }
}
