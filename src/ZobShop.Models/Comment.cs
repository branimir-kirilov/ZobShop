using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class Comment
    {
        public Comment()
        {
            this.DateAnswered = DateTime.Now;
        }

        [Key]
        public int CommentId { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime DateAnswered { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [ForeignKey("Id")]
        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
