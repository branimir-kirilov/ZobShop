using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Orders
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICartLineFactory factory;
        private readonly IProductService service;
        private readonly IOrderService orderService;
        private readonly IOrderFactory orderFactory;

        public ShoppingCart(ICartLineFactory factory,
            IProductService service,
            IOrderService orderService,
            IOrderFactory orderFactory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (orderService == null)
            {
                throw new ArgumentNullException("orderService cannot be null");
            }

            this.factory = factory;
            this.service = service;
            this.orderService = orderService;
            this.orderFactory = orderFactory;

            this.CartLines = new Collection<ICartLine>();
        }

        public ICollection<ICartLine> CartLines { get; private set; }

        public void AddItem(int productId, int quantity)
        {
            var line = this.CartLines
                .FirstOrDefault(l => l.Product.ProductId == productId);

            if (line == null)
            {
                var product = this.service.GetById(productId);

                if (product != null)
                {
                    line = this.factory.CreateCartLine(product, quantity);
                    this.CartLines.Add(line);
                }
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(int productId)
        {
            var line = this.CartLines.FirstOrDefault(l => l.Product.ProductId == productId);

            if (line != null)
            {
                this.CartLines.Remove(line);
            }
        }

        public decimal ComputeTotal()
        {
            return this.CartLines
                .Sum(l => l.Quantity * l.Product.Price);
        }

        public void ClearCart()
        {
            this.CartLines.Clear();
        }

        public void FinishOrder(string name, string address, string phoneNumber)
        {
            var products = this.CartLines
                .Select(l => this.orderFactory.CreateProductOrder(l.Product, l.Quantity))
                .ToList();

            var total = this.ComputeTotal();

            var order = this.orderService.CreateOrder(name, address, phoneNumber, total, products);

            if (order != null)
            {
                this.CartLines = new Collection<ICartLine>();
            }
        }
    }
}
