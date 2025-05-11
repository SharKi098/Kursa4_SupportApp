using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Пр4;

namespace Пр4.Models
{
    [Table("Users")]
    public class UsersModel
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }

        [StringLength(100)]
        [Column("department")]
        public string Department { get; set; }  // NULLABLE

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Навигационные свойства
        [ForeignKey("RoleId")]
        public virtual RoleModel Role { get; set; }

        public virtual ICollection<TicketsModel> CreatedTickets { get; set; }
        public virtual ICollection<TicketsModel> AssignedTickets { get; set; }
        public virtual ICollection<KnowledgeBaseModel> KnowledgeBases { get; set; } // Добавлено!
        public virtual ICollection<CommentsModel> Comments { get; set; }
        public virtual ICollection<NotificationsModel> Notifications { get; set; }
        public virtual ICollection<AssetsModel> Assets { get; set; }
    }
}