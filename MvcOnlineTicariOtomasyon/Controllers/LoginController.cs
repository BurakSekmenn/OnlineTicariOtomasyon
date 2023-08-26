using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult LoginKayıt()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult LoginKayıt(Cariler t)
        {
            c.Carilers.Add(t);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler ca)
        {
            var bilgiler= c.Carilers.FirstOrDefault(x=>x.CariMail == ca.CariMail && x.CariSifre==ca.CariSifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel"); 
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
         
        }
        [HttpGet]
        public ActionResult AdminLogin() { 
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategoriler");
            }
            else
            {
                ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre.";
                return RedirectToAction("Index", "Login");
            }
           
        }
    }
}