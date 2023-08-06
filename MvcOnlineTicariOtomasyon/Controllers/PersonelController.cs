using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> personeldepbul = (from x in c.Departmans.ToList()
                                                   where x.Durum == true
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DepartmanAd,
                                                       Value = x.Departmanid.ToString()
                                                   }).ToList();

            ViewBag.dgr1 = personeldepbul;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel k)
        {
           

            c.Personels.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir (int id)
        {
            List<SelectListItem> personeldepbul = (from x in c.Departmans.ToList()
                                                   where x.Durum == true
                                                   select new SelectListItem
                                                   {
                                                       Text = x.DepartmanAd,
                                                       Value = x.Departmanid.ToString()
                                                   }).ToList();

            ViewBag.dgr1 = personeldepbul;


            var prs = c.Personels.Find(id);
         
            return View("PersonelGetir",prs);

        }
        public ActionResult PersonelGuncelle (Personel per)
        {
            var personel=c.Personels.Find(per.Personelid);
            personel.PersonelAd = per.PersonelAd;
            personel.PersonelSoyadı = per.PersonelSoyadı;
            personel.PersonelGorsel = per.PersonelGorsel;
            personel.Departmanid = per.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}