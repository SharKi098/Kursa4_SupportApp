using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{

    [Table("Categories")]
    public class CategoriesModel
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("category_name")]
        public string CategoryName { get; set; }

        public virtual ICollection<KnowledgeBaseModel> KnowledgeBases { get; set; }
        public virtual ICollection<TicketsModel> Tickets { get; set; }
    }

}
