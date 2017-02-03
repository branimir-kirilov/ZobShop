using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZobShop.Models
{
    public class Review
    {
        private ICollection<Comment> comments;

        public Review()
        {
            this.comments = new HashSet<Comment>();
            this.Date = DateTime.Now;
        }

        [Key]
        public int ReviewId { get; set; }

        public int Rating { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("Id")]
        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}
