using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.Services.Contracts
{
    public interface IOrderService
    {
        Order CreateOrder(string name, string address, string phoneNumber, decimal total, ICollection<ProductOrder> products);
    }
}
