using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPasajeDatos.Views.Home
{
    public class DemoViewDataController : Controller
    {
        // GET: UsarViewData
        public ActionResult UsarViewData()
        {
            ViewData["Numero"] = 1234;
            return View();
        }
    }
}