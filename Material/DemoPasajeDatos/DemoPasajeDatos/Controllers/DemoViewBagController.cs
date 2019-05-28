using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoPasajeDatos.Views.Home
{
    public class DemoViewBagController : Controller
    {
        // GET: UsarViewBag
        public ActionResult UsarViewBag()
        {
            ViewBag.Numero = 1234;
            return View();
        }
        public ActionResult VerificarSiSobrevive(string valorViewbag)
        {
            ViewBag.Guardado = Request.QueryString["valorViewbag"];
            return View();
        }
        public ActionResult CargarViewBag()
        {
             ViewBag.Texto="Un texto cualquiera en ViewBag";
            return RedirectToAction("OtroMetodo");
        }
        public ActionResult OtroMetodo()
        {
            string texto = ViewBag.Texto;
            return RedirectToAction("Index","Home");
        }
    }
}