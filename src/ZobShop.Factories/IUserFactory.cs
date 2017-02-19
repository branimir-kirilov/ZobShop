using ZobShop.Models;

namespace ZobShop.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email, string name, string phoneNumber, string address);
    }
}
