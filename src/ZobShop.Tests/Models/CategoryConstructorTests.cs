using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Models
{
    [TestFixture]
    public class CategoryConstructorTests
    {
        [Test]
        public void Constructor_Should_InitializeCategory()
        {
            var category = new Category();

            Assert.IsNotNull(category);
        }

        [TestCase("Name")]
        [TestCase("AnotherName")]
        public void Constructor_Should_InitiliazeNameCorrectly(string name)
        {
            var category = new Category(name);

            Assert.AreSame(category.Name, name);
        }
    }
}
