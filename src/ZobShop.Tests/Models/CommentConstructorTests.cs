using System;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models
{
    [TestFixture]
    public class CommentConstructorTests
    {
        [Test]
        public void Constructor_Should_InitializeCommentCorrectly()
        {
            var comment = new Comment();

            Assert.IsNotNull(comment);
        }
    }
}
