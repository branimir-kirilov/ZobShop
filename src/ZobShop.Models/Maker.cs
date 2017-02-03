using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZobShop.Models
{
    public class Maker
    {
        private ICollection<Product> products;

        public Maker()
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        public int MakerId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
