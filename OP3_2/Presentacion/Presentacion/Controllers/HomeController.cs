using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using Dominio.Repositorios;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
       
        public RepositorioBarrio repoBar = new RepositorioBarrio();
        public RepositorioUsuario repoUsu = new RepositorioUsuario();
        public RepositorioVivienda repoViv = new RepositorioVivienda();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //LOGIN REGISTER
        public ActionResult LoginRegister()
        {
            return View();
        }

        //CERRAR SESION
        public ActionResult CerrarSesion()
        {
            Session["logueado"] = false;
            Session["rol"] = "";
            Session["email"] = "";
            return View("Index");
        }

        //LOGIN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult Login(string Email, string Pass)
        {
            if (ModelState.IsValid)
            {
                //Busca si existe un objeto con ese mail y ese password
                var usu = repoUsu.FindByEmail(Email);

                //Si el Loggeo es correcto
                if (usu != null)
                {
                    if (usu.Pass == Usuario.EncriptarPass(Pass, usu.Salt, Usuario.getPimienta()))
                    {
                        //Le agrega los datos a la Session
                        Session["logueado"] = true;
                        Session["email"] = usu.Email;
                        Session["rol"] = usu.Rol;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Contraseña Incorrecta");
                        return View();
                    }

                }
                //Si el Loggeo es incorrecto
                else
                {
                    ModelState.AddModelError("", "Mail o contraseña Incorrectos");
                    return View();
                }
            }
            return View(User);
        }


        public ActionResult LeerArchivo() {
            return View();
        }
        
        public ActionResult LeerArchivosTexto() {
            
            //BARRIOS
            List<Barrio> listaBarrios = new List<Barrio>();

            string pathBarrios = Server.MapPath("~/Archivos/Barrios.txt");            
            List<string> linesBarrios = System.IO.File.ReadAllLines(pathBarrios).ToList();
            foreach (var line in linesBarrios) {
                string[] entries = line.Split('#');
                Barrio bar = new Barrio();
                bar.Nombre = entries.First().ToString();
                bar.Descripcion = entries.Last();

                listaBarrios.Add(bar);

                
            }

            repoBar.AgregarListaBarrios(listaBarrios);

            //PARAMETROS
            string pathParametros = Server.MapPath("~/Archivos/Parametros.txt");
            List<string> linesParametros = System.IO.File.ReadAllLines(pathParametros).ToList();
            foreach (var line in linesParametros)
            {
                Parametro par = new Parametro();
                string[] entries = line.Split('#');

                foreach (var val in entries) {
                    string[] valores = val.Split('=');
                    par.Nombre = valores.First().ToString();
                    par.Valor = valores.Last();

                    var existe = repoViv.FindByParametroName(par.Nombre);

                    if (existe == null)
                    {
                        repoViv.AddParametro(par);
                    }
                }
            }

            //VIVIENDAS
            string pathViviendas = Server.MapPath("~/Archivos/Viviendas.txt");
            List<string> linesViviendas = System.IO.File.ReadAllLines(pathViviendas).ToList();
            foreach (var line in linesViviendas)
            {
                bool existe = false;
                string[] entries = line.Split('#');
                Vivienda viv = new Vivienda();
                // 0   1       2            3              4       5        6        7      8      9        10      11
                //Id#calle#numeroPuerta#nombreBarrio#descripcion#baños#dormitorios#metraje#año#preciofinal#tipo#montoContribucion
                Barrio bar = new Barrio();

                bar = repoBar.FindByName(entries[3].ToString());

                viv.Calle = entries[1].ToString();
                viv.Numero = entries[2].ToString();
                viv.Barrio = bar;
                viv.Descripcion = entries[4].ToString();
                viv.Banios = entries[5];
                viv.Dormitorios = Convert.ToInt32(entries[6]);
                viv.Metraje = Convert.ToInt32(entries[7]);
                viv.Anio = Convert.ToInt32(entries[8]);
                viv.PrecioFinal = Convert.ToDouble(entries[9]);
                viv.Tipo = entries[10];
                viv.Contribucion = Convert.ToDouble(entries[11]);

                //var existe = db.Viviendas.Where(v =>  == viv.Nombre).FirstOrDefault();
                if (existe == false)
                {
                    repoViv.Add(viv);                    
                }
            }


            //return View(repoBar.FindAll().ToList());
            //return View("Index");
            return RedirectToAction("ListaCarga");
        }

        public ActionResult ListaCarga(){
            
            ListaBarrioVivienda modelo = new ListaBarrioVivienda();
            modelo.barrios = repoBar.FindAll().ToList();
            modelo.viviendas = repoViv.FindAll().ToList();

            return View(modelo);

        }


    }
}