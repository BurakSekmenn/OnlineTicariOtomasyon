using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalemViewModel
    {
        public string Aciklama { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }
    }
}