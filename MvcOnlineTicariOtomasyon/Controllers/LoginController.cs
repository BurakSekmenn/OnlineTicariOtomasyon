using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}