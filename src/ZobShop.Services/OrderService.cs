using System.Collections.Generic;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderFactory factory;
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderFactory factory, IRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            this.factory = factory;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public Order CreateOrder(string name, string address, string phoneNumber, decimal total, ICollection<ProductOrder> products)
        {
            var order = this.factory.CreateOrder(name, address, phoneNumber, total);

            order.Products = products;

            this.orderRepository.Add(order);
            this.unitOfWork.Commit();

            return order;
        }
    }
}
