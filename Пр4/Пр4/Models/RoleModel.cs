using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{
    [Table("Roles")]
    public class RoleModel
    {
        [Key]
        [Column("role_id")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("role_name")]
        public string RoleName { get; set; }

        public virtual ICollection<UsersModel> Users { get; set; }
    }
}
