using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x=>x.CariMail == mail.ToString()).Select(y=>y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x=>x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.mesajlars.Where(x=>x.Alici == mail).ToList();
            var gelensayisi = c.mesajlars.Count(x=>x.Alici == mail).ToString();
            ViewBag.d1= gelensayisi;
            var gonderdiğimmesaj = c.mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.d2 = gonderdiğimmesaj;
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult Yenimesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenimesaj(mesajlar m)
        {
            return View();
        }
    }
}