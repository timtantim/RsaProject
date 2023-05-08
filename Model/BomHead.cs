using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
namespace RsaProject.Model
{
    public class BomHead
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [Key]
        public string BomCode { get; set; }
        [Required]
        [StringLength(20)]
        public string MaterialCode { get; set; }
        [Required]
        public string Description { get; set; }

        //RelationShips 一個物料可由多種物料所構成
        [ForeignKey("BomCode")]
        public virtual ICollection<BomDetail> BomDetail { get; set; }

    }
}
