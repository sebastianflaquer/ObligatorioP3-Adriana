using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolaMundo.Controllers
{
    public class PruebasViewbagController : Controller
    {
        // GET: PruebasViewbag
        public ActionResult Index()
        {

            ViewBag.Nombre = "Blanca";
            ViewBag.Hoy = DateTime.Today.ToShortDateString();
            ViewBag.hoy = DateTime.Today.ToLongDateString();
            //return View();
            //return RedirectToAction("OtroMetodo");
            //return View("OtraVista");
            return View("~/Views/Segundo/Index.cshtml");
        }

        public ActionResult OtroMetodo()
        {
            if (ViewBag.Hoy != null)
            {
                DateTime hoy = Convert.ToDateTime(ViewBag.Hoy);
                ViewBag.Maniana = hoy.AddDays(1);
            }
            else
            {
                ViewBag.Maniana = "No tengo idea de qué día es mañana";
            }
            return View();
        }
    }
}