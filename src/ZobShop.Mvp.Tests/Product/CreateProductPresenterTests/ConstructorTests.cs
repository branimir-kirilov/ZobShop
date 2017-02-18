using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter.Product.Create;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.CreateProductPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICreateProductView>();

            Assert.Throws<ArgumentNullException>(() => new CreateProductPresenter(mockedView.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<ICreateProductView>();
            var mockedService = new Mock<IProductService>();

            Assert.DoesNotThrow(() => new CreateProductPresenter(mockedView.Object, mockedService.Object));
        }


        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ICreateProductView>();
            var mockedService = new Mock<IProductService>();

            var presenter = new CreateProductPresenter(mockedView.Object, mockedService.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
