using NUnit.Framework;
using ZobShop.ModelViewPresenter.Administration.UsersList;

namespace ZobShop.Mvp.Tests.VIewModels.UserDetailsViewModelTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase("pesho@pesho.com", "1 Peshov street", "08971235420", "pesho", "abvd-1akd")]
        [TestCase("john@johny.com", "1st Boulevard", "+885-123-1185", "johny", "abcd-c1kd")]
        public void TestGetAddress_ShouldReturnCorrectly(string email, string address, string phoneNumber,
            string username, string id)
        {
            var viewModel = new UserDetailsViewModel(email, address, phoneNumber, username, id);

            Assert.AreEqual(address, viewModel.Address);
        }

        [TestCase("pesho@pesho.com", "1 Peshov street", "08971235420", "pesho", "abvd-1akd")]
        [TestCase("john@johny.com", "1st Boulevard", "+885-123-1185", "johny", "abcd-c1kd")]
        public void TestGetEmail_ShouldReturnCorrectly(string email, string address, string phoneNumber,
           string username, string id)
        {
            var viewModel = new UserDetailsViewModel(email, address, phoneNumber, username, id);

            Assert.AreEqual(email, viewModel.Email);
        }

        [TestCase("pesho@pesho.com", "1 Peshov street", "08971235420", "pesho", "abvd-1akd")]
        [TestCase("john@johny.com", "1st Boulevard", "+885-123-1185", "johny", "abcd-c1kd")]
        public void TestGetPhoneNumber_ShouldReturnCorrectly(string email, string address, string phoneNumber,
           string username, string id)
        {
            var viewModel = new UserDetailsViewModel(email, address, phoneNumber, username, id);

            Assert.AreEqual(phoneNumber, viewModel.PhoneNumber);
        }

        [TestCase("pesho@pesho.com", "1 Peshov street", "08971235420", "pesho", "abvd-1akd")]
        [TestCase("john@johny.com", "1st Boulevard", "+885-123-1185", "johny", "abcd-c1kd")]
        public void TestGetUsername_ShouldReturnCorrectly(string email, string address, string phoneNumber,
           string username, string id)
        {
            var viewModel = new UserDetailsViewModel(email, address, phoneNumber, username, id);

            Assert.AreEqual(username, viewModel.Username);
        }

        [TestCase("pesho@pesho.com", "1 Peshov street", "08971235420", "pesho", "abvd-1akd")]
        [TestCase("john@johny.com", "1st Boulevard", "+885-123-1185", "johny", "abcd-c1kd")]
        public void TestGetId_ShouldReturnCorrectly(string email, string address, string phoneNumber,
           string username, string id)
        {
            var viewModel = new UserDetailsViewModel(email, address, phoneNumber, username, id);

            Assert.AreEqual(id, viewModel.UserId);
        }
    }
}
