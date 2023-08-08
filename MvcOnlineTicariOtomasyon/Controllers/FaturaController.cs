using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult FaturaEkle() { return View(); }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar id) {

            c.Faturalars.Add(id);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id) { 
            var deger = c.Faturalars.Find(id);
            return View("FaturaGetir", deger);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var faturaguncel = c.Faturalars.Find(f.Faturaid);
            faturaguncel.FaturaSıraNo = f.FaturaSıraNo;
            faturaguncel.FaturaSerino = f.FaturaSerino;
            faturaguncel.Tarih = f.Tarih;
            faturaguncel.VergiDairesi = f.VergiDairesi;
            faturaguncel.Saat = f.Saat;
            faturaguncel.TeslimEden = f.TeslimEden;
            faturaguncel.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var dpt = c.Faturalars.Where(x => x.Faturaid == id).Select(y => "Fatura Serino: " + y.FaturaSerino + " Fatura Sıra No: " + y.FaturaSıraNo + " Saat: " + y.Saat).First();
            ViewBag.d = dpt;
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturkal)
        {
            c.FaturaKalems.Add(faturkal);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}