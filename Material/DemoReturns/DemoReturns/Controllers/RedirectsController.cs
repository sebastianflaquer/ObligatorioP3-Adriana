using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoReturns.Models;

namespace DemoReturns.Controllers
{
    public class RedirectsController : Controller
    {
        // GET: Redirects
        public ViewResult Index()
        {
            Plato unPlato = new Plato("Café con leche", "Café con unas gotas de leche", 100);

            return View(unPlato);
        }
        public ViewResult MostrarVista()
        {
            return View("OtraVista");
        }
        public ViewResult MostrarVistaConObjeto()
        {
            return View("OtraVista", new Plato { Nombre = "Fideos con tuco" });
        }
        public ViewResult MostrarVistaOtroController()
        {
            //Aunque esto funciona no es lo ideal. Sería preferible utilizar un RedirectToAction
            //y desde allí retornar la vista convencional.
            return View("~/Views/Otro/MetodoA.cshtml", new Plato { Nombre = "Fideos con tuco" });
        }
        public ActionResult RedireccionarAOtroMetodo()
        {
            Plato unPlato = new Plato("Café con leche de otrro método", "Café con unas gotas de leche", 100);
            return RedirectToAction("OtroMetodo", unPlato);//si no hay que pasarle valores, puede usarse solo el primer parámetro
        }
        public ActionResult OtroMetodo(Plato unP)
        {
            return View(unP);
        }
        public ActionResult RedireccionarAOtroController()
        {
            Plato unPlato = new Plato("Café con leche de otro controller", "Café con unas gotas de leche", 100);
            return RedirectToAction("MetodoA", "Otro", unPlato);//si no hay que pasarle valores, puede usarse solo el primer parámetro
        }
    }
}