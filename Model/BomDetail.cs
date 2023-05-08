using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RsaProject.Model
{
    public class BomDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [Key]
        public string BomCode { get; set; }
        [Required]
        [StringLength(20)]
        public string ChildMaterialCode { get; set; }
        [Required]
        public int MaterialNum { get; set;}

      


    }
}
