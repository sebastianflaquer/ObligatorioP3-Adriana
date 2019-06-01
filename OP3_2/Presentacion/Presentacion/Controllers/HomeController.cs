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
       
        //REPOSITORIOS
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


        //LEER ARHIVO
        public ActionResult LeerArchivo() {
            return View();
        }
        
        //LEER ARCHIVOS EXTO
        public ActionResult LeerArchivosTexto() {

            //BARRIOS
            List<Barrio> listaBarrios = new List<Barrio>();

            string pathBarrios = Server.MapPath("~/Archivos/Barrios.txt");
            List<string> linesBarrios = System.IO.File.ReadAllLines(pathBarrios, System.Text.Encoding.UTF8).ToList();
            foreach (var line in linesBarrios)
            {
                string[] entries = line.Split('#');
                Barrio bar = new Barrio();

                bar.Nombre = entries.First().ToString();
                bar.Descripcion = entries.Last();

                listaBarrios.Add(bar);
            }
            repoBar.AgregarListaBarrios(listaBarrios);



            //PARAMETROS
            List<Parametro> listaParametro = new List<Parametro>();

            string pathParametros = Server.MapPath("~/Archivos/Parametros.txt");
            List<string> linesParametros = System.IO.File.ReadAllLines(pathParametros, System.Text.Encoding.UTF8).ToList();

            foreach (var line in linesParametros)
            {

                string[] entries = line.Split('#');

                foreach (var val in entries)
                {

                    Parametro par = new Parametro();
                    string[] valores = val.Split('=');

                    par.Nombre = valores.First().ToString();
                    string valorString = valores.Last().ToString();

                    //valida que el valor sea un decimal
                    decimal nuevoVal;
                    bool result = decimal.TryParse(valorString, out nuevoVal);

                    par.Valor = nuevoVal;

                    if (result)
                    {
                        listaParametro.Add(par);
                    }

                }
            }
            repoViv.AgregarListaParametros(listaParametro);

            //VIVIENDAS
            List<Vivienda> listaViviendas = new List<Vivienda>();

            string pathViviendas = Server.MapPath("~/Archivos/Viviendas.txt");
            List<string> linesViviendas = System.IO.File.ReadAllLines(pathViviendas, System.Text.Encoding.UTF8).ToList();

            foreach (var line in linesViviendas)
            {
                string[] entries = line.Split('#');
                Vivienda viv = new Vivienda();

                // 0   1       2            3              4       5        6        7      8      9        10      11
                //Id#calle#numeroPuerta#nombreBarrio#descripcion#baños#dormitorios#metraje#año#preciofinal#tipo#montoContribucion
                //CARGA EL BARRIO

                //string nombreBarrio = entries[3].ToString();
                //Barrio bar = new Barrio();
                //bar = repoBar.FindByName(nombreBarrio);

                viv.Id = Convert.ToInt32(entries[0]);
                viv.Calle = entries[1].ToString();
                viv.Numero = entries[2].ToString();
                viv.Barrio = entries[3].ToString();
                viv.Descripcion = entries[4].ToString();
                viv.Banios = Convert.ToInt32(entries[5].ToString());
                viv.Dormitorios = Convert.ToInt32(entries[6]);
                viv.Metraje = Convert.ToInt32(entries[7]);
                viv.Anio = Convert.ToInt32(entries[8]);
                viv.PrecioFinal = Convert.ToDecimal(entries[9]);
                viv.Tipo = entries[10];
                viv.Contribucion = Convert.ToDecimal(entries[11]);

                Vivienda vivEncontrada = repoViv.FindById(viv.Id);

                listaViviendas.Add(viv);

            }
            repoViv.AgregarListaVivienda(listaViviendas);



            //bool barrios = LeerArchivoBarrios();
            //bool parametros = LeerArchivoParametros();
            //bool viviendas = LeerArchivoViviendas();

            //RETURN REDIRECTOACTION
            //return View();
            return RedirectToAction("ListaCarga");
        }

        //LEER ARCHIVO BARRIOS
        //private bool LeerArchivoBarrios()
        //{
        //    return true;
        //}

        ////LEER ARCHIVO PARAMETROS
        //private bool LeerArchivoParametros()
        //{
        //    return true;
        //}

        ////LEER ARCHIVO VIVIENDAS
        //private bool LeerArchivoViviendas()
        //{
        //    return true;
        //}


        //LISTA CARGA
        public ActionResult ListaCarga(){
            ListaBarrioViviendaViewModel modelo = new ListaBarrioViviendaViewModel();
            modelo.barrios = repoBar.FindAll().ToList();
            modelo.viviendas = repoViv.FindAll().ToList();
            return View(modelo);
        }


    }
}