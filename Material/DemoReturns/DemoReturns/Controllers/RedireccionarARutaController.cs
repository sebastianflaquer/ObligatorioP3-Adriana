using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoReturns.Controllers
{
    public class RedireccionarARutaController : Controller
    {
        // GET: RedireccionarARuta
        public ActionResult Index()
        {
            return RedirectToRoute("RutaPrueba");//Hay una entrada en RouteConfig.cs que se llama prueba.
        }
        public ActionResult RedirecionarConParametros()
        {
            return RedirectToRoute("RutaPrueba", new { action="Index",Nombre = "Juliana" });//Hay una entrada en RouteConfig.cs que se llama prueba.
        }
        public ActionResult RedireccionarAUrl()
        {
            return Redirect("https://www.ort.edu.uy");
        }
    }
}