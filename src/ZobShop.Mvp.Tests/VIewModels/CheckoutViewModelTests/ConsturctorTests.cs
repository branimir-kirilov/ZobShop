using NUnit.Framework;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;

namespace ZobShop.Mvp.Tests.VIewModels.CheckoutViewModelTests
{
    [TestFixture]
    public class ConsturctorTests
    {
        [TestCase("Ivan", "Peshova street", "0884167954")]
        [TestCase("Pesho", "Peshova street", "0884387195")]
        [TestCase("Stamat", "Peshova street", "098712469")]
        public void TestConstructor_PassValidValues_ShouldInitializeCorrectly(string name,
            string address,
            string phoneNumber)
        {
            var model = new CheckoutViewModel(name, address, phoneNumber);

            Assert.IsNotNull(model);
        }

        [TestCase("Ivan", "Peshova street", "0884167954")]
        [TestCase("Pesho", "Peshova street", "0884387195")]
        [TestCase("Stamat", "Peshova street", "098712469")]
        public void TestConstructor_PassValidValues_ShouldSetNameCorrectly(string name,
            string address,
            string phoneNumber)
        {
            var model = new CheckoutViewModel(name, address, phoneNumber);

            Assert.AreEqual(name, model.Name);
        }

        [TestCase("Ivan", "Peshova street", "0884167954")]
        [TestCase("Pesho", "Peshova street", "0884387195")]
        [TestCase("Stamat", "Peshova street", "098712469")]
        public void TestConstructor_PassValidValues_ShouldSetAddressCorrectly(string name,
            string address,
            string phoneNumber)
        {
            var model = new CheckoutViewModel(name, address, phoneNumber);

            Assert.AreEqual(address, model.Address);
        }

        [TestCase("Ivan", "Peshova street", "0884167954")]
        [TestCase("Pesho", "Peshova street", "0884387195")]
        [TestCase("Stamat", "Peshova street", "098712469")]
        public void TestConstructor_PassValidValues_ShouldSetPhoneNumberCorrectly(string name,
            string address,
            string phoneNumber)
        {
            var model = new CheckoutViewModel(name, address, phoneNumber);

            Assert.AreEqual(phoneNumber, model.PhoneNumber);
        }
    }
}
