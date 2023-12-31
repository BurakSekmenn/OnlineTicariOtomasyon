﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int Cariid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 Karakter Yazabilirsiniz.")]
        public string Cariad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyadı { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail{ get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSifre { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}