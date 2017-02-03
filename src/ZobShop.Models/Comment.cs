using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
