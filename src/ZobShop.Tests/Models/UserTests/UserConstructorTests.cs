using Microsoft.AspNet.Identity.EntityFramework;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.UserTests
{
    [TestFixture]
    public class UserConstructorTests
    {
        [Test]
        public void Constructor_Should_InitializeUserCorrectly()
        {
            var user = new User();

            Assert.IsNotNull(user);
        }

        [Test]
        public void Constructor_Should_BeInstanceOfIdentityUser()
        {
            var user = new User();

            Assert.IsInstanceOf<IdentityUser>(user);
        }

        [TestCase("pesho", "pesho@pesho.com", "Peter", "0881768356", "1 Peshova street")]
        public void Constructor_ShouldSetUsernameCorrectly(string username, string email, string name, string phoneNumber, string address)
        {
            var user = new User(username, email, name, phoneNumber, address);

            Assert.AreEqual(username, user.UserName);
        }

        [TestCase("pesho", "pesho@pesho.com", "Peter", "0881768356", "1 Peshova street")]
        public void Constructor_ShouldSetNameCorrectly(string username, string email, string name, string phoneNumber, string address)
        {
            var user = new User(username, email, name, phoneNumber, address);

            Assert.AreEqual(name, user.Name);
        }

        [TestCase("pesho", "pesho@pesho.com", "Peter", "0881768356", "1 Peshova street")]
        public void Constructor_ShouldSeEmailCorrectly(string username, string email, string name, string phoneNumber, string address)
        {
            var user = new User(username, email, name, phoneNumber, address);

            Assert.AreEqual(email, user.Email);
        }

        [TestCase("pesho", "pesho@pesho.com", "Peter", "0881768356", "1 Peshova street")]
        public void Constructor_ShouldSetPhoneNumberCorrectly(string username, string email, string name, string phoneNumber, string address)
        {
            var user = new User(username, email, name, phoneNumber, address);

            Assert.AreEqual(phoneNumber, user.PhoneNumber);
        }

        [TestCase("pesho", "pesho@pesho.com", "Peter", "0881768356", "1 Peshova street")]
        public void Constructor_ShouldSetAddressCorrectly(string username, string email, string name, string phoneNumber, string address)
        {
            var user = new User(username, email, name, phoneNumber, address);

            Assert.AreEqual(address, user.Address);
        }
    }
}
