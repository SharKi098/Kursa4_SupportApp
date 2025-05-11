using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{
    [Table("Comments")]
    public class CommentsModel
    {
        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }

        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; } 

        [Required]
        [Column("comment_text")]  
        public string CommentText { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Навигационные свойства
        [ForeignKey("TicketId")]
        public virtual TicketsModel Ticket { get; set; }

        [ForeignKey("UserId")]
        public virtual UsersModel User { get; set; }
    }
}
