using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.OrderTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestConstructor_ShouldSetNameCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var order = new Order(name, address, phoneNumber, total);

            Assert.AreEqual(name, order.Name);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestConstructor_ShouldSetAddressCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var order = new Order(name, address, phoneNumber, total);

            Assert.AreEqual(address, order.Address);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestConstructor_ShouldSetPhoneNumberCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var order = new Order(name, address, phoneNumber, total);

            Assert.AreEqual(phoneNumber, order.PhoneNumber);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestConstructor_ShouldSetTotalCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var order = new Order(name, address, phoneNumber, total);

            Assert.AreEqual(total, order.Total);
        }
    }
}
