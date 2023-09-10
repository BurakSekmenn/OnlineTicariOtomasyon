using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
        public ActionResult PartialInvoiceDetail(int id)
        {
            ViewBag.list = c.Faturalars.Where(x => x.Faturaid == id).ToList();
            ViewBag.value = c.Faturalars.Where(x => x.Faturaid == id)
                .Select(y => y.FaturaSerino + " " + y.FaturaSıraNo).FirstOrDefault();
            return PartialView("_FaturaDetayPop");
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
        public ActionResult Dinamik()
        {
            // class 2 de IEnumerable oluşturduk çünkü 2 farklı veritabanınndan veri alabilmek için .
            Class2 cs = new Class2();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSeriNo,string FaturaSıraNo,DateTime tarih,string VergiDairesi, string Saat, string TeslimEden,string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
           
                Faturalar f = new Faturalar();
                f.FaturaSerino = FaturaSeriNo;
                f.FaturaSıraNo = FaturaSıraNo;
                f.Tarih = tarih;
                f.VergiDairesi = VergiDairesi;
                f.Saat = Saat;
                f.TeslimEden = TeslimEden;
                f.TeslimAlan = TeslimAlan;
                f.Toplam = decimal.Parse(Toplam);
                c.Faturalars.Add(f);
                c.SaveChanges();
                return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
            
        }
    }
}