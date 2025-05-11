using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Пр4.Models
{
    [Table("Assets")]
    public class AssetsModel
    {
        [Key]
        [Column("asset_id")]
        public int AssetId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("asset_name")]
        public string AssetName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("asset_type")]
        public string AssetType { get; set; }

        [Column("assets_to")]
        public int? AssetsTo { get; set; }  

        [Required]
        [StringLength(15)]
        [Column("status")]
        public string Status { get; set; }  

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("AssetsTo")]
        public virtual UsersModel AssignedUser { get; set; }
    }
}

