using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.ProductsListPresenterTests
{
    [TestFixture]
    public class ViewProductDeleteTests
    {
        [TestCase(1)]
        [TestCase(13)]
        [TestCase(47)]
        public void TestViewProductDelete_ShouldCallServiceDeleteProduct(int id)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedService = new Mock<IProductService>();

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var args = new DeleteProductEventArgs(id);
            mockedView.Raise(v => v.ProductDelete += null, args);

            mockedService.Verify(s => s.DeleteProduct(id), Times.Once);
        }
    }
}
