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
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           where x.Durum == true
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
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
            var deger = c.SatisHarekets.Find(id);
            return View(deger);
        }
        public ActionResult SatisGuncelle(SatisHareket sat)
        {
            var satgu = c.SatisHarekets.Find(sat.Satisid);
            satgu.Cariid = sat.Cariid;
            satgu.Adet = sat.Adet;
            satgu.Fiyat = sat.Fiyat;
            satgu.Personelid = sat.Personelid;
            satgu.ToplamTutar = sat.ToplamTutar;
            satgu.Tarih = sat.Tarih;
            satgu.Urunid = sat.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x=>x.Satisid == id).ToList();
            return View(degerler);
        }

    }
}