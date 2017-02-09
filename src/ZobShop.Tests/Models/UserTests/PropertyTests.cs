using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.UserTests
{
    [TestFixture]
    public class PropertyTests
    {
        [TestCase("street")]
        [TestCase("highway")]
        [TestCase("boulevard")]
        public void TestAddressProperty_ShouldWorkCorrectly(string address)
        {
            var user = new User();
            user.Address = address;

            Assert.AreEqual(address, user.Address);
        }
    }
}
