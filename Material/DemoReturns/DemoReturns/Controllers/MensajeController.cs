﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoReturns.Controllers
{
    public class MensajeController : Controller
    {
        // GET: Mensaje
        public ActionResult Index(string nombre)
        {
            if (nombre == null)
                ViewBag.Nombre = "Ninguno";
            else
                ViewBag.Nombre = nombre;
            return View();
        }
    }
}