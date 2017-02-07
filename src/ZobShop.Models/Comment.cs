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

        public int ReviewId { get; set; }

        [ForeignKey("ReviewId")]
        public virtual Review Review { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string Id { get; set; }

        [ForeignKey("Id")]
        public User Author { get; set; }
    }
}
