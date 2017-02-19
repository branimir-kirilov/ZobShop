using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.ProductsListPresenterTests
{
    [TestFixture]
    public class ViewProductEditTests
    {
        [TestCase(1)]
        [TestCase(231)]
        public void TestViewProductEdit_ShouldCallServiceGetById(int id)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedService = new Mock<IProductService>();

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel { Id = id };
            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedService.Verify(s => s.GetById(id), Times.Once);
        }

        [TestCase(1, "category")]
        [TestCase(231, "category")]
        public void TestViewProductEdit_ShouldCallServiceEdit(int id, string categoryName)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();

            var category = new Category(categoryName);
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(product);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Category = categoryName
            };

            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedService.Verify(s => s.EditProduct(product), Times.Once);
        }

        [TestCase(1, "category")]
        [TestCase(231, "category")]
        public void TestViewProductEdit_PassSameCategoryName_ShouldNotCallCategoryServiceGetCategoryByName(int id, string categoryName)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();

            var category = new Category(categoryName);
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(product);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Category = categoryName
            };

            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedCategoryService.Verify(s => s.GetCategoryByName(categoryName), Times.Never);
        }

        [TestCase(1, "category")]
        [TestCase(231, "category")]
        public void TestViewProductEdit_PassDifferentCategory_ShouldCallCategoryServiceGetCategoryByName(int id, string categoryName)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();

            var category = new Category("test");
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(product);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Category = categoryName
            };

            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedCategoryService.Verify(s => s.GetCategoryByName(categoryName), Times.Once);
        }

        [TestCase(1, "category")]
        [TestCase(231, "category")]
        public void TestViewProductEdit_PassDifferentCategory_ServiceReturnsNull_ShouldCallCategoryServiceCreateCategory(int id, string categoryName)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();

            var category = new Category("test");
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(product);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Category = categoryName
            };

            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedCategoryService.Verify(s => s.CreateCategory(categoryName), Times.Once);
        }



        [TestCase(1, "category")]
        [TestCase(231, "category")]
        public void TestViewProductEdit_PassDifferentCategory_ServiceReturnsCategory_ShouldNotCallCategoryServiceCreateCategory(int id, string categoryName)
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var category = new Category("test");
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(product);

            var mockedCategoryService = new Mock<ICategoryService>();
            mockedCategoryService.Setup(s => s.GetCategoryByName(It.IsAny<string>())).Returns(category);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            var model = new ProductDetailsViewModel
            {
                Id = id,
                Category = categoryName
            };

            var args = new EditProductEventArgs(model);
            mockedView.Raise(v => v.ProductEdit += null, args);

            mockedCategoryService.Verify(s => s.CreateCategory(categoryName), Times.Never);
        }
    }
}
