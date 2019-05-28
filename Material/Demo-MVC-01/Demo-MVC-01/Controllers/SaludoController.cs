using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_MVC_01.Controllers
{
    public class SaludoController : Controller
    {
        // GET: Saludo
        public ActionResult Saludar()
        {
            return View();
        }
    }
}