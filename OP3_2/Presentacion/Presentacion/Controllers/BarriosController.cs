using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dominio.Models;
using Dominio.Repositorios;

namespace Presentacion.Controllers
{
    public class BarriosController : Controller
    {
        public RepositorioBarrio repoBar = new RepositorioBarrio();

        // GET: Barrios
        public ActionResult Index()
        {
            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                return View(repoBar.FindAll().ToList());
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Home");
            }
        }

        // GET: Barrios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Barrio barrio = repoBar.FindById(id);
                if (barrio == null)
                {
                    return HttpNotFound();
                }
                return View(barrio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Home");
            }
        }

        // GET: Barrios/Create
        public ActionResult Create()
        {
            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                return View();
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Home");
            }
        }

        // POST: Barrios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                repoBar.Add(barrio);
                return RedirectToAction("Index");
            }

            return View(barrio);
        }

        // GET: Barrios/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Barrio barrio = repoBar.FindById(id);
                if (barrio == null)
                {
                    return HttpNotFound();
                }
                return View(barrio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Home");
            }
        }

        // POST: Barrios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                repoBar.Update(barrio);

                return RedirectToAction("Index");
            }
            return View(barrio);
        }

        // GET: Barrios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Barrio barrio = repoBar.FindById(id);
                if (barrio == null)
                {
                    return HttpNotFound();
                }
                return View(barrio);
            }
            else //Si no esta logeado
            {
                return RedirectToAction("../Home");
            }
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrio barrio = repoBar.FindById(id);
            bool elimino = repoBar.Delete(barrio);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoBar.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
