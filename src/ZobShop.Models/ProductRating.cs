using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class ProductRating
    {
        [Key]
        public int ProductRatingId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Id")]
        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
