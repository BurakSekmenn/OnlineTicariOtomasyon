using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int Faturaid { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSerino { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime Tarih { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string VergiDairesi { get; set; }
        public DateTime  Saat { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden { get;  set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan { get;  set; }

        public ICollection<FaturaKalem>  FaturaKalems { get; set; }
    }
}