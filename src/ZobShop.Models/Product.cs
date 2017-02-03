using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class Product
    {
        private ICollection<Review> reviews;
        private ICollection<ProductRating> productRatings;

        public Product()
        {
            this.reviews = new HashSet<Review>();
            this.productRatings = new HashSet<ProductRating>();
        }

        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public double Volume { get; set; }

        [ForeignKey("MakerId")]
        public int MakerId { get; set; }

        public Maker Maker { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<ProductRating> ProductRatings
        {
            get { return this.productRatings; }
            set { this.productRatings = value; }
        }
    }
}
