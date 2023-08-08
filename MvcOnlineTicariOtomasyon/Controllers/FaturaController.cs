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
    }
}