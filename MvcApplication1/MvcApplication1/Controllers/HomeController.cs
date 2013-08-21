using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }    

        public ActionResult Comer()
        {  
            return View();
        }

        public ActionResult Beber()
        {
            return View();
        }

        public ActionResult Receta()
        {
            return View();
        }

        public ActionResult Calendario()
        {
            return View();
        }


        public ActionResult Registro()
        {
            return View();
        }
    }
}
