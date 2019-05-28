using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoRestaurant.Models;

namespace DemoRestaurant.Controllers
{
    public class PlatoController : Controller
    {
        // GET: Plato
        public ActionResult Index()
        {
            return View(SistemaRestaurant.LaInstancia.LosPlatos);
        }
        //este responde al GET
        public ActionResult CrearHtml()
        {
            return View("CrearHtml");
        }
        //Este se ejecuta cuando hacen se envía el formulario por submit()
        [HttpPost]
        public ActionResult CrearHtml(Plato unPlato)
        {
            if (unPlato == null)
                return new HttpNotFoundResult("No se recibió el plato para guardar");
            if (unPlato.EsValido())
            {
                if (SistemaRestaurant.LaInstancia.AgregarPlato(unPlato))
                {
                    ViewBag.Estado = "Plato ingresado";
                    ModelState.Clear();
                    return View("CrearHtml", new Plato());
                }
            }
            ModelState.AddModelError("nombre", "El nombre es incorrecto");
            ViewBag.Estado = "Plato no guardado. Revise los valores ingresados ";
            return View( unPlato);
        }
    }
}
