using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string urunad { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string urunbilgi { get; set; }

        
    }
}