using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ShoppingCart(ICartLineFactory factory, IProductService service)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            this.factory = factory;
            this.service = service;

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
    }
}
