using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index(int id)
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Uruns.Where(x=>x.Urunid == id).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == id).ToList();

           

            var urun = c.Uruns.Find(id);
            var urunList = new List<Urun> { urun };
            ViewBag.urunresim = urun.UrunGorsel;
            ViewBag.urunfiyat = urun.SatisFiyat;
            ViewBag.urunad = urun.UrunAd;
            return View(urunList);
        }
    }
}