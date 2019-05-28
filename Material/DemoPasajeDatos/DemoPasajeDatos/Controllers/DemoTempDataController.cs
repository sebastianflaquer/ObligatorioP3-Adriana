using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPasajeDatos.Controllers
{
    public class DemoTempDataController : Controller
    {
        // GET: DemoTempData
        public ActionResult Index()
        {
            //1. Carga tempdata por primera vez
            TempData["Nombre"] = "Juan";
            TempData["OtroNombre"] = "Pepe";
            return View();
        }
        public ActionResult RecuperarTempData()
        {
            //2. Viene desde el link de la view Index 
            if (TempData["Nombre"] != null)
            {
                string nombre = TempData["Nombre"].ToString();
            }
            return RedirectToAction("RecuperarNuevamenteTempData");
       }
        //3. Viene desde recuperar tempData. TempData["OtroNombre"] no se consumió.
        public ActionResult RecuperarNuevamenteTempData()
        {
            string nombre = "Está vacío"; string otroNombre = "Está vacío";
            if (TempData["Nombre"] != null)
                nombre = TempData["Nombre"].ToString();
            if (TempData["OtroNombre"] != null)
                otroNombre = TempData["OtroNombre"].ToString();
            ViewBag.LoQueTieneTempData =
                string.Format("Nombre: {0} y OtroNombre: {1}", nombre, otroNombre);
            return View();
        }
    }
}