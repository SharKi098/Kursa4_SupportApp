using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Пр4.Models
{
    [Table("Tickets")]
    public class TicketsModel
    {
        [Key]
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        [Column("status")]
        public string Status { get; set; } 

        [Required]
        [StringLength(10)]
        [Column("priority")]
        public string Priority { get; set; }  

        [Column("category_id")]
        public int? CategoryId { get; set; }  

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("assigned_to")]
        public int? AssignedTo { get; set; } 

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }  

        // Навигационные свойства
        [ForeignKey("CategoryId")]
        public virtual CategoriesModel Category { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual UsersModel CreatedByUser { get; set; }

        [ForeignKey("AssignedTo")]
        public virtual UsersModel AssignedToUser { get; set; }  // Исправлено на Users

        public virtual ICollection<CommentsModel> Comments { get; set; }
    }
}