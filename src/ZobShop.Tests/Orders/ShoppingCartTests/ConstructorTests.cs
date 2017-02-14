using System;
using Moq;
using NUnit.Framework;
using ZobShop.Orders;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Orders.ShoppingCartTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() => new ShoppingCart(null, mockedService.Object));
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<ICartLineFactory>();

            Assert.Throws<ArgumentNullException>(() => new ShoppingCart(mockedFactory.Object, null));
        }

        [Test]
        public void TestConstructor_PassCorrectly_ShouldNotThrow()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();

            Assert.DoesNotThrow(() => new ShoppingCart(mockedFactory.Object, mockedService.Object));
        }

        [Test]
        public void TestConstructor_PassCorrectly_ShouldInitialiseCartLinesCorrectly()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object);

            Assert.IsNotNull(cart.CartLines);
        }
    }
}
