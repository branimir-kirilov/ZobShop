using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class ProductRating
    {
        [Key]
        public int ProductRatingId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Id")]
        public User Author { get; set; }
    }
}
