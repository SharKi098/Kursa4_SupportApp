using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{
    [Table("Notifications")]
    public class NotificationsModel
    {
        [Key]
        [Column("notification_id")]
        public int NotificationId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; } 

        [Required]
        [Column("message")]
        public string Message { get; set; }

        [Required]
        [StringLength(10)]
        [Column("type")]  
        public string Type { get; set; }

        [Required]
        [StringLength(10)]  
        [Column("status")]
        public string Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual UsersModel User { get; set; }
    }
}
