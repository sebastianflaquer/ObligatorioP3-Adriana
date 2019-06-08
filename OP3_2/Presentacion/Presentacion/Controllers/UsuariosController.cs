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
    public class UsuariosController : Controller
    {
        public RepositorioUsuario repoUsu = new RepositorioUsuario();
        
        // GET: Usuarios
        public ActionResult Index()
        {
            //return View();
            return View(repoUsu.FindAll());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = repoUsu.FindById(id);
            //Usuario usuario = db.Usuarios.Find(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usu)
        {

            //BUSCA SI HAY UN USUARIO CON EL MISMO EMAIL
            var existe = repoUsu.FindByCedula(usu.Cedula);

            //SI EL USUARIO YA EXISTE
            if (existe != null)
            {
                ModelState.AddModelError("", "Ya existe un usuario con ese numero de Cedula");
            }
            else
            {
                //usu.Rol = usu.getRol();
                usu.Salt = usu.generarSalPass();
                usu.Pass = Usuario.EncriptarPass(usu.Pass, usu.Salt, Usuario.getPimienta());

                if (ModelState.IsValid)
                {
                    repoUsu.Add(usu);
                    ModelState.Clear();
                    //ViewBag.Message = usu.Email + " - " + usu.Pass + " se registro correctamente";
                    return RedirectToAction("../Home/Index");
                }
            }
            return View();
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuario usuario = repoUsu.FindById(id);
            //Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Rol,Cedula,Nombre,Apellido,FechaNac,Email,Pass,Salt")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                repoUsu.Update(usuario);
                //db.Entry(usuario).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = repoUsu.FindById(id);
            //Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = repoUsu.FindById(id);
            //Usuario usuario = db.Usuarios.Find(id);

            bool elimino = repoUsu.Delete(usuario);
            
            return RedirectToAction("Index");
        }

        //LOGEARSE
        public ActionResult LoggedIn()
        {
            if (Session["email"] != null)
            {
                Session["logueado"] = true;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repoUsu.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
