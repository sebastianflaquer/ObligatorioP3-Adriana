﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.Models;
using Dominio.Repositorios;
using Repositorios.Repositorios;

namespace Presentacion.Controllers
{
    public class ViviendasController : Controller
    {
        public RepositorioSorteo repoSor = new RepositorioSorteo();
        public RepositorioBarrio repoBar = new RepositorioBarrio();
        public RepositorioVivienda repoViv = new RepositorioVivienda();

        // GET: Viviendas
        public ActionResult Index()
        {
            return View(repoViv.FindAll().ToList());
        }

        // GET: Viviendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vivienda vivienda = repoViv.FindById(id);

            if (vivienda == null)
            {
                return HttpNotFound();
            }
            return View(vivienda);
        }

        // GET: Viviendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viviendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Habilitada,Calle,Numero,Barrio,Descripcion,Banios,Dormitorios,Metraje,Anio,PBaseXMetroCuadrado,PrecioFinal")] Vivienda vivienda)
        {
            if (ModelState.IsValid)
            {
                repoViv.Add(vivienda);
                return RedirectToAction("Index");
            }

            return View(vivienda);
        }

        // GET: Viviendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vivienda vivienda = repoViv.FindById(id);

            if (vivienda == null)
            {
                return HttpNotFound();
            }
            return View(vivienda);
        }

        // POST: Viviendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Estado,Calle,Numero,Barrio,Descripcion,Banios,Dormitorios,Metraje,Anio,PBaseXMetroCuadrado,PrecioFinal")] Vivienda vivienda)
        {
            if (ModelState.IsValid)
            {
                repoViv.Update(vivienda);

                return RedirectToAction("Index");
            }
            return View(vivienda);
        }

        // GET: Viviendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vivienda vivienda = repoViv.FindById(id);

            if (vivienda == null)
            {
                return HttpNotFound();
            }
            return View(vivienda);
        }

        // POST: Viviendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vivienda vivienda = repoViv.FindById(id);

            repoViv.Delete(vivienda);
            return RedirectToAction("Index");
        }

        //MODIFICAR VIVIENDA
        public ActionResult ModificarVivienda()
        {
            return View(repoViv.FindAll().ToList());
        }

        //AJAX
        //MODIFICAR VIVIENDA DATA
        public JsonResult ModificarViviendaData(string BuscarPor, string SearchValue)
        {
            List<Vivienda> listaViviendas = new List<Vivienda>();

            if (BuscarPor == "Id")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    listaViviendas.Add(repoViv.FindById(Id));
                }
                catch (FormatException) {
                    Console.WriteLine("{0} Is not a ID ", SearchValue);
                }
            }

            return Json(listaViviendas, JsonRequestBehavior.AllowGet);
        }
        
        //AJAX
        //BUSCAR VVIENDA DATA
        public JsonResult BuscarViviendaData(string BuscarPor, string SearchValue)
        {
            List<Vivienda> listaViviendas = new List<Vivienda>();
            if (BuscarPor == "1") //Cantidad de dormitorios
            {
                try
                {
                    listaViviendas = repoViv.buscarViviendasPorDormitorios(SearchValue).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}  Error al buscar la vivienda - dormitorios ", SearchValue);
                }
            }
            else if (BuscarPor == "2") //Rango de precio
            {
                try
                {
                    decimal min = 0;
                    decimal max = 0;

                    if (SearchValue == "1") {
                        min = 0;
                        max = Convert.ToDecimal("50000.00");
                    }
                    else if (SearchValue == "2")
                    {
                        min = Convert.ToDecimal("50001.00");
                        max = Convert.ToDecimal("75000.00");
                    }
                    else if (SearchValue == "3")
                    {
                        min = Convert.ToDecimal("75001.00");
                        max = Convert.ToDecimal("100000.00");
                    }
                    listaViviendas = repoViv.buscarViviendasPorRango(min, max).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Error al buscar la vivienda - rango ", SearchValue);
                }
            }
            else if (BuscarPor == "3") //por BARRIO
            {
                try
                {
                    listaViviendas = repoViv.buscarViviendasPorBarrio(SearchValue).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}  Error al buscar la vivienda - barrio", SearchValue);
                }
            }
            else if (BuscarPor == "4") //ESTADO
            {
                try
                {
                    listaViviendas = repoViv.buscarViviendasPorEstado(SearchValue).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0}  Error al buscar la vivienda - estado", SearchValue);
                }
            }
            //else if (BuscarPor == "5") //TIPO
            //{ 
            //    try
            //    {
            //        if (SearchValue == "M") {
            //            listaViviendas = repoViv.buscarViviendasNuevas.ToList();
            //        }
            //        else {
            //            listaViviendas = repoViv.buscarViviendasUsadas.ToString();
            //        }
                    
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("{0}  Error al buscar la vivienda - tipo", SearchValue);
            //    }
            //}

            return Json(listaViviendas, JsonRequestBehavior.AllowGet);
        }

        // GET: Viviendas/Details/5
        public ActionResult ModificarViviendaDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vivienda vivienda = repoViv.FindById(id);

            if (vivienda == null)
            {
                return HttpNotFound();
            }
            return View(vivienda);
        }


        // POST: Viviendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "Id,Habilitada")] Vivienda vivienda)
        {
            if (ModelState.IsValid)
            {
                repoViv.Update(vivienda);

                return RedirectToAction("Index");
            }
            return View(vivienda);
        }

        //BUSCAR VIVIENDA
        public ActionResult BuscarVivienda() {


            List<SelectListItem> newList = new List<SelectListItem>();
            List<Barrio> listaBarrios = repoBar.FindAll().ToList();
            foreach (var item in listaBarrios)
            {
                SelectListItem itemList = new SelectListItem { Text = item.Nombre, Value = item.Nombre };
                newList.Add(itemList);
            }

            ViewData["listaBarrios"] = newList;
            
            return View(repoViv.FindAll().ToList());
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoViv.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
