using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{
    [Table("KnowledgeBase")]
    public class KnowledgeBaseModel
    {
        [Key]
        [Column("article_id")]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(200)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Column("category_id")]
        public int? CategoryId { get; set; } 

        [Column("created_by")]
        public int? CreatedBy { get; set; }    

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Навигационные свойства
        [ForeignKey("CategoryId")]
        public virtual CategoriesModel Category { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual UsersModel CreatedByUser { get; set; }
    }
}
