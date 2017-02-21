using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class ProductOrder
    {
        public ProductOrder(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        [Key]
        public int ProductOrderId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
