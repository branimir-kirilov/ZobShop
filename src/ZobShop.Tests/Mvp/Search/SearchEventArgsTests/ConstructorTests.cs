using NUnit.Framework;
using ZobShop.ModelViewPresenter.Search;

namespace ZobShop.Tests.Mvp.Search.SearchEventArgsTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase("str")]
        [TestCase("search")]
        [TestCase("lalala")]
        [TestCase("query")]
        public void TestConstructor_ShouldSetupSearchQueryStringCorrectly(string searchQuery)
        {
            var args = new SearchEventArgs(searchQuery);

            Assert.AreEqual(searchQuery, args.SearchQueryString);
        }


        [TestCase("query")]
        public void TestConstructor_ShouldInitializeCorrectly(string searchQuery)
        {
            var args = new SearchEventArgs(searchQuery);

            Assert.IsNotNull(args);
        }
    }
}
