using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZobShop.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<ProductOrder>();
        }

        public Order(string name, string address, string phoneNumber, decimal total)
            : this()
        {
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Total = total;
        }

        [Key]
        public int OrderId { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<ProductOrder> Products { get; set; }
    }
}
