using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolaMundo.Controllers
{
    public class BienvenidaController : Controller
    {
        // GET: Bienvenida
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Saludar() {
            return View();
        }

    }
}