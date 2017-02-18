using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter.Account.Login;

namespace ZobShop.Mvp.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ILoginView>();

            var presenter = new LoginPresenter(mockedView.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
