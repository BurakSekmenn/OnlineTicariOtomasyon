﻿using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacaController : Controller
    {
        Context c = new Context();
        // GET: Yapilaca
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
           
            //var deger4 =c.Carilers.Distinct().Count(x=>x.CariSehir.to).ToString();
            var deger = c.Yapilacaks.ToList();
            return View(deger);
        }
    }
}