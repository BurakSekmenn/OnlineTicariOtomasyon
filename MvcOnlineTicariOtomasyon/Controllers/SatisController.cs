using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degere= c.SatisHarekets.ToList();
            return View(degere);
        }
        [HttpGet]
        public ActionResult YeniSatis() {
            List <SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                        where x.Durum == true
                                        select new SelectListItem
                                        {
                                            Text=x.UrunAd,
                                            Value=x.Urunid.ToString()
                                        }).ToList();
            ViewBag.dgr1=deger1;
            List<SelectListItem> deger2 = (from a in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = a.Cariad + " " + a.CariSoyadı,
                                               Value = a.Cariid.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from b in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = b.PersonelAd + " " + b.PersonelSoyadı,
                                               Value = b.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
           satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }

    }
}