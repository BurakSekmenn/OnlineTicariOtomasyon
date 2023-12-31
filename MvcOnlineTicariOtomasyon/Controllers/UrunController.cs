﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList() select new SelectListItem {

                Text =x.KategoriAd,
                Value = x.KategoriID.ToString()
            }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urundeger = c.Uruns.Find(id);
            urundeger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var urundege= c.Uruns.Find(id);
            return View("UrunGuncelle",urundege);
        }
        public ActionResult UrunDuzenle (Urun p)
        {
            var urn =c.Uruns.Find(p.Urunid);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.kategoriid=p.kategoriid;
            urn.Marka=p.Marka;
            urn.SatisFiyat=p.SatisFiyat;
            urn.Stok=p.Stok; 
            urn.UrunAd=p.UrunAd;
            urn.UrunGorsel=p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyadı,

                                               Value = x.Personelid.ToString()
                                           }).ToList();
            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Cariad + " " + x.CariSoyadı,
                                             Value = x.Cariid.ToString()
                                         }).ToList();
            ViewBag.personel=personel;
            ViewBag.cari=cari;

            var deger = c.Uruns.Find(id);
            ViewBag.dgr1 = deger.Urunid;
            ViewBag.dgr2 = deger.SatisFiyat;

            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket k)
        {
            k.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}