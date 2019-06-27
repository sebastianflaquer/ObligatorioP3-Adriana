using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using Dominio.Repositorios;
using Repositorios.Repositorios;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
       
        //REPOSITORIOS
        public RepositorioBarrio repoBar = new RepositorioBarrio();
        public RepositorioUsuario repoUsu = new RepositorioUsuario();
        public RepositorioVivienda repoViv = new RepositorioVivienda();
        public RepositorioSorteo repoSor = new RepositorioSorteo();

        // GET: Home
        public ActionResult Index()
        {
            cargarDatosPrueba();
            return View();
        }

        //CARGAR DATOS PRUEBA
        private void cargarDatosPrueba()
        {
            cargaUsuariosBase();
            LeerArchivosTexto();
            modificarViviendas();
            crearSorteos();
        }
        
        //CARGA USUARIOS BASE
        private void cargaUsuariosBase()
        {
            List<Jefe> listaUsuariosJefe = new List<Jefe>();
            List<Postulante> listaUsuariosPostulantes = new List<Postulante>();

            Jefe usuAdmin = new Jefe();

            usuAdmin.Cedula = "45173353";
            usuAdmin.Nombre = "Sebastian";
            usuAdmin.Apellido = "Flaquer";
            usuAdmin.Email = "sebastian.flaquer@gmail.com";
            usuAdmin.Rol = "Jefe";
            usuAdmin.Pass = "123456";
            usuAdmin.ConfirmPassword = "123456";
            usuAdmin.FechaNac = "1987-05-12";
            listaUsuariosJefe.Add(usuAdmin);
            
            Postulante usuPostu3 = new Postulante();
            usuPostu3.Cedula = "33333333";
            usuPostu3.Nombre = "Juan";
            usuPostu3.Apellido = "Perez";
            usuPostu3.Email = "juanperez@gmail.com";
            usuPostu3.Rol = "Postulante";
            usuPostu3.Pass = "123456";
            usuPostu3.ConfirmPassword = "123456";
            usuPostu3.FechaNac = "1987-05-12";
            listaUsuariosPostulantes.Add(usuPostu3);

            Postulante usuPostu2 = new Postulante();
            usuPostu2.Cedula = "22222222";
            usuPostu2.Nombre = "Maria";
            usuPostu2.Apellido = "Rodriguez";
            usuPostu2.Email = "mrodriguez@gmail.com";
            usuPostu2.Rol = "Postulante";
            usuPostu2.Pass = "123456";
            usuPostu2.ConfirmPassword = "123456";
            usuPostu2.FechaNac = "1987-05-12";
            listaUsuariosPostulantes.Add(usuPostu2);

            Postulante usuPostu = new Postulante();
            usuPostu.Cedula = "11111111";
            usuPostu.Nombre = "Lucas";
            usuPostu.Apellido = "Torreira";
            usuPostu.Email = "ltorreira@gmail.com";
            usuPostu.Rol = "Postulante";
            usuPostu.Pass = "123456";
            usuPostu.ConfirmPassword = "123456";
            usuPostu.FechaNac = "1987-05-12";
            listaUsuariosPostulantes.Add(usuPostu);

            Postulante usuPostu4 = new Postulante();
            usuPostu4.Cedula = "44444444";
            usuPostu4.Nombre = "Luis";
            usuPostu4.Apellido = "Suarez";
            usuPostu4.Email = "lsuarez@gmail.com";
            usuPostu4.Rol = "Postulante";
            usuPostu4.Pass = "123456";
            usuPostu4.ConfirmPassword = "123456";
            usuPostu4.FechaNac = "1987-05-12";
            listaUsuariosPostulantes.Add(usuPostu4);

            repoUsu.AgregarListaUsuarios(listaUsuariosPostulantes);
            repoUsu.AgregarListaUsuariosJefe(listaUsuariosJefe);

        }

        private void modificarViviendas()
        {
            repoViv.cambiarEstado(1, "Habilitada");
            repoViv.cambiarEstado(2, "Habilitada");
            repoViv.cambiarEstado(5, "Habilitada");
            repoViv.cambiarEstado(8, "Habilitada");
            repoViv.cambiarEstado(10, "Habilitada");
            repoViv.cambiarEstado(13, "Habilitada");
        }

        private void crearSorteos()
        {
            Sorteo sor1 = new Sorteo();
            sor1.Fecha = Convert.ToDateTime("2019-06-28 00:00:00.000");
            sor1.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor1, 1);

            Sorteo sor2 = new Sorteo();
            sor2.Fecha = Convert.ToDateTime("2019-06-27 00:00:00.000");
            sor2.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor2, 2);

            Sorteo sor3 = new Sorteo();
            sor3.Fecha = Convert.ToDateTime("2019-06-30 00:00:00.000");
            sor3.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor3, 5);

            Sorteo sor4 = new Sorteo();
            sor4.Fecha = Convert.ToDateTime("2019-06-29 00:00:00.000");
            sor4.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor4, 8);

            Sorteo sor5 = new Sorteo();
            sor5.Fecha = Convert.ToDateTime("2019-07-01 00:00:00.000");
            sor5.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor5, 10);

            Sorteo sor6 = new Sorteo();
            sor6.Fecha = Convert.ToDateTime("2019-07-02 00:00:00.000");
            sor6.Hora = Convert.ToDateTime("2019-06-27 01:00:00.000");
            repoSor.crearSorteo(sor6, 13);

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
            if (Session["rol"].ToString() == "Jefe") //Si esta logeado
            {
                return View();
            }
            else //Si no esta logeado
            {   
                return RedirectToAction("../Home");
            }
        }
        
        //LEER ARCHIVOS EXTO
        public ActionResult LeerArchivosTexto() {
            
            bool barrios = LeerArchivoBarrios();
            bool parametros = LeerArchivoParametros();
            bool viviendas = LeerArchivoViviendas();

            //RETURN REDIRECTOACTION
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