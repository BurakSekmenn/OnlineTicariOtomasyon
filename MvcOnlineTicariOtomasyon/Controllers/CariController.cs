using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.ToList();
            return View(degerler);
        }
        public ActionResult CariSil(int id)
        {
            var carisil = c.Carilers.Find(id);
            c.Carilers.Remove(carisil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var carilerbul = c.Carilers.Find(id);
            return View("CariGetir",carilerbul);
        }
        public ActionResult CariGuncelle(Cariler bul)
        {
            var caridgr = c.Carilers.Find(bul.Cariid);
            caridgr.Cariad = bul.Cariad;
            caridgr.CariSoyadı = bul.CariSoyadı;
            caridgr.CariMail = bul.CariMail;
            caridgr.CariSehir = bul.CariSehir;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}