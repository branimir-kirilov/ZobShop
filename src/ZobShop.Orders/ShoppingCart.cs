using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZobShop.Models;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;

namespace ZobShop.Orders
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICartLineFactory factory;

        public ShoppingCart(ICartLineFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.factory = factory;

            this.CartLines = new Collection<ICartLine>();
        }

        public ICollection<ICartLine> CartLines { get; private set; }

        public void AddItem(Product product, int quantity)
        {
            var line = this.CartLines
                .FirstOrDefault(l => l.Product.ProductId == product.ProductId);

            if (line == null)
            {
                line = this.factory.CreateCartLine(product, quantity);
                this.CartLines.Add(line);
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            var line = this.CartLines.FirstOrDefault(l => l.Product.ProductId == product.ProductId);

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
            this.CartLines = new Collection<ICartLine>();
        }
    }
}
