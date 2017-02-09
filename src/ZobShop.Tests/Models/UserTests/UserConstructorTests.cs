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
    }
}
