using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.Models;
using Repositorios.Repositorios;
using Dominio.Repositorios;

namespace Presentacion.Controllers
{
    public class SorteosController : Controller
    {
        public RepositorioSorteo repoSor = new RepositorioSorteo();
        public RepositorioBarrio repoBar = new RepositorioBarrio();
        public RepositorioVivienda repoViv = new RepositorioVivienda();

        // GET: Sorteos
        public ActionResult Index()
        {
            return View(repoSor.FindAll().ToList());
        }

        // GET: Sorteos
        public ActionResult Realizar()
        {
            return View(repoSor.FindAll().ToList());
        }

        // GET: Sorteos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = repoSor.FindById(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }

        // GET: Sorteos/Create
        public ActionResult Create()
        {
            List<SelectListItem> newList = new List<SelectListItem>();
            List<Barrio> listaBarrios = repoBar.FindAll().ToList();
            foreach (var item in listaBarrios)
            {
                SelectListItem itemList = new SelectListItem { Text = item.Nombre, Value = item.Nombre};
                newList.Add(itemList);
            }
            ViewData["listaBarrios"] = newList;

            return View();
        }

        //AJAX
        //CREAR SORTEO
        public JsonResult CreateSorteo(string BuscarBarrio)
        {
            List<Vivienda> listaViviendas = repoViv.buscarViviendasPorBarrio(BuscarBarrio);
            return Json(listaViviendas, JsonRequestBehavior.AllowGet);
        }

        // POST: Sorteos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora")] Sorteo sorteo, int idVivienda)
        {
            if (ModelState.IsValid)
            {
                repoSor.crearSorteo(sorteo, idVivienda);
                return RedirectToAction("Index");
            }

            return View(sorteo);
        }


        // GET: Sorteos/Edit/5
        public ActionResult InscribirUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = repoSor.FindById(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InscribirUsuario([Bind(Include = "Id")] Sorteo sorteo)
        {
            if (ModelState.IsValid)
            {
                string cedulaUsuario = Session["email"].ToString();

                repoSor.inscribirUsuario(sorteo.Id, cedulaUsuario);
                //repoSor.Update(sor);
                return RedirectToAction("Index");
            }
            return View(sorteo);
        }


        // GET: Sorteos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = repoSor.FindById(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }


       

        // POST: Sorteos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora")] Sorteo sorteo)
        {
            if (ModelState.IsValid)
            {
                repoSor.Update(sorteo);

                return RedirectToAction("Index");
            }
            return View(sorteo);
        }

        // GET: Sorteos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = repoSor.FindById(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }

        // POST: Sorteos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sorteo sorteo = repoSor.FindById(id);

            repoSor.Delete(sorteo);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoSor.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
