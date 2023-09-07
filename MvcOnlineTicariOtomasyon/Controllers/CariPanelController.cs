using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.Where(x => x.CariMail == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariid).FirstOrDefault();
            ViewBag.mid=mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.toplamsatis=toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.ToplamTutar);
            ViewBag.toplamtutar=toplamtutar;
            var toplamurunsayisi = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.Adet);
            ViewBag.toplamurunsayisi = toplamurunsayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x=>x.CariMail == mail.ToString()).Select(y=>y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x=>x.Cariid == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x=>x.Alici == mail).OrderByDescending(x=>x.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x=>x.Alici == mail).ToString();
            ViewBag.d1= gelensayisi;
            var gonderdiğimmesaj = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gonderdiğimmesaj;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(z=>z.MesajID).ToList();
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gonderdiğimmesaj = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gonderdiğimmesaj;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gonderdiğimmesaj = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gonderdiğimmesaj;
            var deger = c.mesajlars.Where(x=>x.MesajID == id).ToList();
            return View("MesajDetay",deger);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Yenimesaj()
        {
            var mail = (string)Session["CariMail"];
            ViewBag.gonderenmail= mail;
            var gelensayisi = c.mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gonderdiğimmesaj = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gonderdiğimmesaj;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Yenimesaj(mesajlar m)
        {
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gonderici = (string)Session["CariMail"];
            c.mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar", "CariPanel");
        }
        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult LogOut() { 
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        } 
    }
}