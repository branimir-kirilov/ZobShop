using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        [Key]
        public int CommentId { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime DateAnswered { get; set; }

        public int ReviewId { get; set; }

        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        [ForeignKey("Id")]
        public virtual User Author { get; set; }
    }
}
