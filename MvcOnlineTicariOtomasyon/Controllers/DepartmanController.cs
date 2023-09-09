using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
       
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult DepartmanEkle() 
        {
            return View(); 
        }
        [HttpPost]
     
        public ActionResult DepartmanEkle(Departman k)
        {
            c.Departmans.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var urundeger = c.Departmans.Find(id);
            urundeger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var deger = c.Departmans.Find(id);
            return View("DepartmanGetir", deger);
        }
        public ActionResult DepartmanGuncelle(Departman k)
        {
            var ktgr = c.Departmans.Find(k.Departmanid);
            ktgr.DepartmanAd = k.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degeler = c.Personels.Where(x=>x.Departmanid == id).ToList();
            var dpt= c.Departmans.Where(x=>x.Departmanid == id).Select(y=>y.DepartmanAd).First();
            ViewBag.d = dpt;
            return View(degeler);
        }
        public ActionResult DepartmanPersonelSatis(int id) {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var dpt = c.Personels.Where(x=>x.Personelid==id).Select(y=>y.PersonelAd +" "+ y.PersonelSoyadı).First();
            ViewBag.dpers = dpt;
            return View(degerler);
        }
        public ActionResult GeneratePDF(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var dpt = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyadı).FirstOrDefault();
            ViewBag.dpers = dpt;

            return new Rotativa.PartialViewAsPdf("tablo", degerler)
            {
                FileName = "PersonelSatislar.pdf",
                PageSize = Rotativa.Options.Size.A4,
                PageOrientation = Rotativa.Options.Orientation.Landscape
            };
        }
        public ActionResult DownloadPDF()
        {
            string filePath = Server.MapPath("~/Rotativa/PersonelSatislar.pdf"); // Önceki PDF dosyasının yolu
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf", "PersonelSatislar.pdf");
        }

    }
}