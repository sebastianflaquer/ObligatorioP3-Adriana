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
            cargaUsuariosBase();
            return View();
        }

        private void cargaUsuariosBase()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            Usuario usuAdmin = new Usuario();
            Usuario usuPostu = new Usuario();

            usuAdmin.Cedula = "45173353";
            usuAdmin.Nombre = "Sebastian";
            usuAdmin.Apellido = "Flaquer";
            usuAdmin.Email = "sebastian.flaquer@gmail.com";
            usuAdmin.Rol = "Jefe";
            usuAdmin.Pass = "123456";
            usuAdmin.ConfirmPassword = "123456";
            usuAdmin.FechaNac = "12/05/1987";

            usuPostu.Cedula = "11111111";
            usuPostu.Nombre = "Test Postulante";
            usuPostu.Apellido = "Test Apellido Postulante";
            usuPostu.Email = "test@test.com";
            usuPostu.Rol = "Postulante";
            usuPostu.Pass = "123456";
            usuPostu.ConfirmPassword = "123456";
            usuPostu.FechaNac = "12/05/1987";

            listaUsuarios.Add(usuAdmin);
            listaUsuarios.Add(usuPostu);

            repoUsu.AgregarListaUsuarios(listaUsuarios);
            
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
        public ActionResult Login(string Cedula, string Pass)
        {
            if (ModelState.IsValid)
            {
                //Busca si existe un objeto con ese mail y ese password
                var usu = repoUsu.FindByCedula(Cedula);

                //Si el Loggeo es correcto
                if (usu != null)
                {
                    if (usu.Pass == Usuario.EncriptarPass(Pass, usu.Salt, Usuario.getPimienta()))
                    {
                        //Le agrega los datos a la Session
                        Session["logueado"] = true;
                        Session["email"] = usu.Cedula;
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
            
            bool barrios = LeerArchivoBarrios();
            bool parametros = LeerArchivoParametros();
            bool viviendas = LeerArchivoViviendas();

            //RETURN REDIRECTOACTION
            //return View();
            return RedirectToAction("ListaCarga");
        }

        //LEER ARCHIVO BARRIOS
        private bool LeerArchivoBarrios()
        {
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

            return true;
        }

        ////LEER ARCHIVO PARAMETROS
        private bool LeerArchivoParametros()
        {
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

            return true;
        }

        ////LEER ARCHIVO VIVIENDAS
        private bool LeerArchivoViviendas()
        {
            //VIVIENDAS
            string pathViviendas = Server.MapPath("~/Archivos/Viviendas.txt");
            List<string> linesViviendas = System.IO.File.ReadAllLines(pathViviendas, System.Text.Encoding.UTF8).ToList();

            repoViv.leerArchivoViviendasRepo(linesViviendas);
            
            return true;
        }


        //LISTA CARGA
        public ActionResult ListaCarga(){
            ListaBarrioViviendaViewModel modelo = new ListaBarrioViviendaViewModel();
            modelo.barrios = repoBar.FindAll().ToList();
            modelo.viviendasNuevas = repoViv.FindAllNuevas().ToList();
            modelo.viviendasUsadas = repoViv.FindAllUsadas().ToList();
            return View(modelo);
        }


    }
}