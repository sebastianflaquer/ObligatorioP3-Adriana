using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoReturns.Models;
namespace DemoReturns.Controllers
{
    public class OtroController : Controller
    {
        // GET: Otro
        public ActionResult MetodoA(Plato unPlato)
        {
            return View(unPlato);
        }
    }
}