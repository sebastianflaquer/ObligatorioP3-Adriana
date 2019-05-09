using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OP3;
using OP3.Dominio;
using OP3.Dominio.Repositorios.Ado;
using System.Text.RegularExpressions;
using System.IO;

namespace OP3.Presentacion
{
    class Program {

        static RepositorioBarrioAdo repoBar = new RepositorioBarrioAdo();
        static RepositorioViviendaAdo repoViv = new RepositorioViviendaAdo();
        static RepositorioUsuarioAdo repoUsu = new RepositorioUsuarioAdo();
        static bool logeado = false;

        //MAIN STATIC
        static void Main(string[] args) {
            int opcion = -1;
            do {
                //if (!logeado){
                //    DibujarMenuInicio();
                //}else {
                //    DibujarMenu();
                //}

                DibujarMenu();

                opcion = LeerOpcion();

                if (opcion != 0)
                    ProcesarMenu(opcion);
            } while (opcion != 0);
            Console.WriteLine("Fin del programa.");
            PararPantalla();
        }

        //PROCESAR MENU
        private static void ProcesarMenu(int opcion) {
            if (opcion == 1) {
                MenuOpcionesBarrio();
            }
            else if (opcion == 2)
            {
                MenuOpcionesViviendas();
            }
            else if (opcion == 3)
            {
                MenuOpcionesUsuarios();
            }
            else if (opcion == 4)
            {
                MenuOpcionesGenerar();
            }
        }

        //LEER OPCION
        private static int LeerOpcion()
        {
            int tope = 5;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;
                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);
            return opcion;
        }

        //PROCESAR MENU BARRIOS
        private static void ProcesarMenuBarrios(int opcion)
        {
            if (opcion == 1)
            {
                MenuAgregarBarrio();
            }
            else if (opcion == 2)
            {
                MenuModificarBarrio();
            }
            else if (opcion == 3)
            {
                MenuEliminarBarrio();
            }
            else if (opcion == 4)
            {
                MenuEliminarBarrio();
            }
            else if (opcion == 5)
            {
                MenuEliminarBarrio();
            }
            else if (opcion == 6)
            {
                MenuEliminarBarrio();
            }
        }

        //MOSTRAR PARAMETROS
        private static void MostrarParámetros() {
            //Pedido p = new Pedido();
            //Console.WriteLine("El valor de la tasa de iva es: {0}", p.LeerTasaBasicaIVA());
            //PiezaUnica u = new PiezaUnica();
            //Console.WriteLine("El valor de la tasa de aumento de una pieza única es: {0}", u.LeerTasaAumento());
            PararPantalla();
        }

        //DIBUJAR MENU INICIO
        private static void DibujarMenuInicio() {
            Console.Clear();
            Console.WriteLine("Bienvenido - Inicio");
            Console.WriteLine("=================");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("1 - Ingresar al Sistema");
            //Console.WriteLine("3 - Mostrar el iva");
            Console.WriteLine("Ingrese una opción - 0 para salir");

            int tope = 1;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;
                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);

            if (opcion == 0)
            {
                PararPantalla();
            }
            else if (opcion == 1)
            {
                MenuLogin();
            }
            else
            {
                DibujarMenuInicio();
            }

        }

        //MENU LOGIN - DONE
        public static void MenuLogin() {

            bool existe = false;

            Console.Clear();
            Console.WriteLine("Iniciar Sesión");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Email:");
            string Email = Console.ReadLine();

            while (Email == "") {
                Console.WriteLine("Tipo de Email no valido debe ingresar un mail valido ej:usuario@sistema.com");
                Console.WriteLine("Ingrese Email:");
                Email = Console.ReadLine();
            }

            Console.WriteLine("Ingrese Contraseña:");
            string Pass = Console.ReadLine();

            while (Pass == "")
            {
                Console.WriteLine("La contraseña debe tener al menos 1 caracter");
                Console.WriteLine("Ingrese Contraseña:");
                Pass = Console.ReadLine();
            }

            existe = ValidarUsuario(Email, Pass);
            logeado = existe;

            while (!existe)
            {
                Console.WriteLine("El Usuario o la Constraseña no son correctos o no existen Intente nuevamente");
                Console.WriteLine("Ingrese Email:");
                Email = Console.ReadLine();
                Console.WriteLine("Ingrese Contraseña:");
                Pass = Console.ReadLine();
                existe = ValidarUsuario(Email, Pass);
            }

            DibujarMenu();

        }

        //VALIDAR USUARIO - DONE
        public static bool ValidarUsuario(string vEmail, string vPass) {
            Usuario Usu = repoUsu.validarUsuario(vEmail, vPass);
            if (Usu != null) {
                if (Usu.Email != null && Usu.Pass != null) {
                    return true;
                }
            }
            return false;
        }

        //DIBUJAR MENU
        private static void DibujarMenu() {
            Console.Clear();
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("=================");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("1 - Opciones de Barrio");
            Console.WriteLine("2 - Opciones de Viviendas");
            Console.WriteLine("3 - Opciones de Usuarios");
            Console.WriteLine("4 - Opciones de Generar Archivos");
            Console.WriteLine("Ingrese una opción - 0 para salir");
        }

        //PARAR PANTALLA
        private static void PararPantalla() {
            Console.WriteLine("Chau, presionar tecla");
            Console.ReadKey();
        }

        //PARAR PANTALLA
        private static void ListoVovler()
        {
            Console.WriteLine("Listo, presionar tecla para volver");
            Console.ReadKey();
        }
        
        ///////////////////////////////////////////////////
        //USUARIOS             
        ///////////////////////////////////////////////////
        private static void MenuOpcionesUsuarios()
        {
            Console.Clear();
            Console.WriteLine("Opciones de Usuarios");
            Console.WriteLine("=================");
            Console.WriteLine("1 - Registrar Usuario");
            Console.WriteLine("2 - Modificar Usuario");
            Console.WriteLine("3 - Eliminar Usuario");
            Console.WriteLine("4 - Menu Test Usuario");
            Console.WriteLine("5 - Listar Usuario");
            Console.WriteLine("6 - Ir Atras");
            Console.WriteLine("Ingrese una opción - 0 para salir");

            int tope = 6;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;

                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);

            if (opcion == 0)
            {
                PararPantalla();
            }
            else if (opcion == 1)
            {
                MenuAgregarUsuario();
            }
            else if (opcion == 2)
            {
                MenuModificarUsuario();
            }
            else if (opcion == 3)
            {
                MenuEliminarUsuario();
            }
            else if (opcion == 4)
            {
                MenuServicioUsuario();
            }
            else if (opcion == 5)
            {
                ListarUsuario();
            }
            else
            {
                DibujarMenu();
            }

        }
        
        ///////////////////////////////////////////////////
        //VIVIENDAS                
        ///////////////////////////////////////////////////
        private static void MenuOpcionesViviendas()
        {
            Console.Clear();
            Console.WriteLine("Opciones Vivienda");
            Console.WriteLine("=================");
            Console.WriteLine("1 - Registrar Vivienda");
            Console.WriteLine("2 - Modificar Vivienda");
            Console.WriteLine("3 - Eliminar Vivienda");
            Console.WriteLine("4 - Listar todas las Viviendas");
            Console.WriteLine("5 - Listar Viviendas por Barrio");
            Console.WriteLine("6 - Ir Atras");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese una opción - 0 para salir");

            int tope = 6;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;

                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);

            if (opcion == 0)
            {
                PararPantalla();
            }
            else if (opcion == 1)
            {
                MenuAgregarVivienda();
            }
            else if (opcion == 2)
            {
                MenuModificarVivienda();
            }
            else if (opcion == 3)
            {
                MenuEliminarVivienda();
            }
            else if (opcion == 4)
            {
                ListarViviendas();
            }
            else if (opcion == 5)
            {
                ListarViviendasXBarrio();
            }
            else if (opcion == 6)
            {

            }
            else
            {
                DibujarMenu();
            }

        }

        ///////////////////////////////////////////////////
        //BARIOS                
        ///////////////////////////////////////////////////
        private static void MenuOpcionesBarrio(){

            Console.Clear();
            Console.WriteLine("Opciones Barrio");
            Console.WriteLine("=================");
            Console.WriteLine("1 - Registrar Barrio");
            Console.WriteLine("2 - Modificar Barrio");
            Console.WriteLine("3 - Eliminar un Barrio");
            Console.WriteLine("4 - Listar todos los Barrios");
            Console.WriteLine("5 - Buscar Barrio por Nombre");
            Console.WriteLine("6 - Ir Atras");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese una opción - 0 para salir");

            int tope = 6;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;

                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);

            if (opcion == 0) {
                PararPantalla();
            } else if (opcion == 1) {
                MenuAgregarBarrio();
            } else if (opcion == 2) {
                MenuModificarBarrio();
            } else if (opcion == 3) {
                MenuEliminarBarrio();
            } else if (opcion == 4) {
                ListarBarrios();
            } else if (opcion == 5) {
                BuscarBarrioXNombre();
            } else if (opcion == 6) {
                DibujarMenu();
            } else {
                DibujarMenu();
            }
        }

        ///////////////////////////////////////////////////
        //GENERAR ARCHIVOS                
        ///////////////////////////////////////////////////
        private static void MenuOpcionesGenerar()
        {

            Console.Clear();
            Console.WriteLine("Opcione Generar Archivos");
            Console.WriteLine("=================");
            Console.WriteLine("1 - Generar todos los archivos");
            Console.WriteLine("2 - Generar Barrios");
            Console.WriteLine("3 - Generar Viviendas");
            Console.WriteLine("4 - Generar Parametros");
            Console.WriteLine("5 - Ir Atras");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese una opción - 0 para salir");

            int tope = 5;
            int opcion = -1;
            bool esNumero = false;
            char caracter;
            do
            {
                caracter = Console.ReadKey().KeyChar;
                esNumero = int.TryParse(caracter.ToString(), out opcion);
                if (!esNumero || opcion < 0 || opcion > tope)
                {
                    Console.WriteLine("Ingrese nuevamente, la opción debe estar entre 0 y {0}", tope);
                }
            } while (!esNumero || opcion < 0 || opcion > tope);

            if (opcion == 0)
            {
                PararPantalla();
            }
            else if (opcion == 1)
            {
                GenerarArchivos();
            }
            else if (opcion == 2)
            {
                GenerarArchivoBarrios();
            }
            else if (opcion == 3)
            {
                GenerarArchivoViviendas();
            }
            else if (opcion == 4)
            {
                GenerarArchivoParametros();
            }
            else if (opcion == 5)
            {
                DibujarMenu();
            }
            else
            {
                DibujarMenu();
            }
        }


        //MENU
        //------------------------------------------------- BARRIOS
        //MENU AGREGAR BARRIO
        private static void MenuAgregarBarrio() {
            bool existe = false;
            string Nombre = "";
            string Descripcion = "";

            Console.Clear();
            Console.WriteLine("Agregar Barrio");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Nombre:");
            Nombre = Console.ReadLine();

            while (Nombre == "")
            {
                Console.WriteLine("El Nombre debe contener al menos 1 caracter");
                Console.WriteLine("Ingrese Nombre:");
                Nombre = Console.ReadLine();
            }

            existe = ValidarBarrio(Nombre);

            while (existe)
            {
                Console.WriteLine("El Barrio " + Nombre + " ya existe, Ingrese Nombre Diferente:");
                Nombre = Console.ReadLine();
                existe = ValidarBarrio(Nombre);
            }

            Console.WriteLine("Ingrese Descripcion:");
            Descripcion = Console.ReadLine();

            while (Descripcion == "")
            {
                Console.WriteLine("La Descripcion debe contener minimo 1 caracter:");
                Descripcion = Console.ReadLine();
            }

            if (!existe) {
                AgregarBarrio(Nombre, Descripcion);
            }
        }

        //MENU MODIFICAR BARRIO
        private static void MenuModificarBarrio()
        {
            bool existe = false;
            string Nombre = "";
            string Descripcion = "";

            Console.Clear();
            Console.WriteLine("Modificar Barrio");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Nombre:");
            Nombre = Console.ReadLine();

            while (Nombre == "")
            {
                Console.WriteLine("El Nombre debe contener al menos 1 caracter");
                Console.WriteLine("Ingrese Nombre:");
                Nombre = Console.ReadLine();
            }

            existe = ValidarBarrio(Nombre);

            while (!existe)
            {
                Console.WriteLine("El Barrio " + Nombre + " no existe, Ingrese Nombre que exista:");
                Nombre = Console.ReadLine();
                existe = ValidarBarrio(Nombre);
            }

            Console.WriteLine("Ingrese Descripcion:");
            Descripcion = Console.ReadLine();

            while (Descripcion == "")
            {
                Console.WriteLine("La Descripcion debe contener al menos 1 caracter");
                Console.WriteLine("Ingrese Descripcion:");
                Nombre = Console.ReadLine();
            }

            ModificarBarrio(Nombre, Descripcion);
        }

        //MENU ELIMINAR BARRIO
        private static void MenuEliminarBarrio() {

            bool existe = false;
            bool tieneViviendas = false;

            Console.Clear();
            Console.WriteLine("Eliminar Barrio");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Nombre:");
            string Nombre = Console.ReadLine();

            existe = ValidarBarrio(Nombre);
            tieneViviendas = repoViv.tieneVivienda(Nombre);

            while (existe == false || tieneViviendas == true) {
                if (!existe) {
                    Console.WriteLine("El Barrio " + Nombre + " no existe, Ingrese Nombre Diferente:");
                    Nombre = Console.ReadLine();
                } else {
                    Console.WriteLine("Debe eliminar las viviendas que existen en este barrio antes de poder eliminar el barrio");
                    Console.WriteLine("Ingrese el nombre de otro barrio:");
                    Nombre = Console.ReadLine();
                }
                existe = ValidarBarrio(Nombre);
                tieneViviendas = repoViv.tieneVivienda(Nombre);
            }

            EliminarBarrio(Nombre);

        }

        //ACCION
        //VALIDAR BARRIO
        public static bool ValidarBarrio(string Nombre) {
            Barrio Bar = repoBar.FindById(Nombre);
            if (Bar.Nombre != null)
            {
                return true;
            }
            return false;
        }

        //AGREGAR BARRIO
        private static void AgregarBarrio(string vNombre, string vDescripcion)
        {
            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var nuevoBarrio = client.AgregarBarrio(vNombre, vDescripcion);

                //if (Lista != null)
                //{
                //    foreach (var elem in Lista)
                //    {
                //        Console.WriteLine(elem.Nombre.ToString() + " - " + elem.Descripcion.ToString());
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("No hay Barrios ingresados:");
                //}
            }

                //repoBar.Add(new Barrio
                //{
                //    Nombre = vNombre,
                //    Descripcion = vDescripcion
                //});
            Console.WriteLine("Barrio Agregado");
            ListoVovler();
            DibujarMenu();
        }

        //ELIMINAR BARRIO
        private static void EliminarBarrio(string vNombre)
        {
            repoBar.Delete(new Barrio
            {
                Nombre = vNombre
            });
            Console.WriteLine("Barrio Eliminado");
            ListoVovler();
            DibujarMenu();
        }

        //MODIFICAR BARRIO
        private static void ModificarBarrio(string vNombre, string vDescripcion)
        {
            repoBar.Update(new Barrio { Nombre = vNombre, Descripcion = vDescripcion });

            Console.WriteLine("Barrio Modificado");
            ListoVovler();
            DibujarMenu();
        }

        //LISTAR BARRIOS
        private static void ListarBarrios()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Lista de Barrios");
            Console.WriteLine("=================");

            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var Lista = client.GetTodosLosBarrios();
                if (Lista != null) {
                    foreach (var elem in Lista)
                    {
                        Console.WriteLine(elem.Nombre.ToString() + " - " + elem.Descripcion.ToString());
                    }
                }
                else {
                    Console.WriteLine("No hay Barrios ingresados:");
                }
            }

            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
        }

        //BUSCAR BARRIO POR NOMBRE
        private static void BuscarBarrioXNombre()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Buscar Barrios por Nombre");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Nombre del Barrio:");
            string Nombre = Console.ReadLine();


            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var Bar = client.BuscarBarrioPorNombre(Nombre);
                if (Bar != null)
                {
                    Console.WriteLine(Bar.Nombre.ToString() + " - " + Bar.Descripcion.ToString());
                }
                else
                {
                    Console.WriteLine("No Existe un Barrio con ese Nombre:");
                }
            }
            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
        }

        //MENU
        //------------------------------------------------- VIVIENDAS
        //MENU AGREGAR VIVIENDA
        private static void MenuAgregarVivienda()
        {

            bool TipoCasa = false;
            bool existeBarrio = false;

            Console.Clear();
            Console.WriteLine("Agregar Vivienda");
            Console.WriteLine("=================");
            Console.WriteLine("La vivienda es Nueva(N) o Usada(U)");
            string Tipo = Console.ReadLine();

            while (Tipo != "N" && Tipo != "U" && Tipo != "n" && Tipo != "u")
            {
                Console.WriteLine("Debe seleccionar si la vivienda es Nueva(N) o Usada(U)");
                Console.WriteLine("Ingrese N o U:");
                Tipo = Console.ReadLine();
            }

            if (Tipo == "N") {
                TipoCasa = true;
            } else if (Tipo == "U") {
                TipoCasa = false;
            }

            //HABILITADA
            int HabilitadaBit = 0;
            Console.WriteLine("La vivienda esta habilidada para la venta? (S o N):");
            string Habilitada = Console.ReadLine();
            Habilitada = Habilitada.ToUpper();

            while (Habilitada != "S" && Habilitada != "N")
            {
                Console.WriteLine("Debe ingresar S o N:");
                Habilitada = Console.ReadLine();
            }

            if (Habilitada == "S") {
                HabilitadaBit = 1;
            }

            //CALLE
            Console.WriteLine("Ingrese Nombre de Calle:");
            string Calle = Console.ReadLine();

            while (Calle == "")
            {
                Console.WriteLine("La Calle debe contener minimo 1 caracter:");
                Calle = Console.ReadLine();
            }

            //NUMERO DE PUERTA
            Console.WriteLine("Ingrese Numero de puerta:");
            string Numero = Console.ReadLine();
            while (Numero == "") {
                Console.WriteLine("Debe Ingresar un Numero de puerta");
                Numero = Console.ReadLine();
            }

            //BARRIO

            Console.WriteLine("Ingrese Barrio:");
            string Barrio = Console.ReadLine();
            while (Barrio == "")
            {
                Console.WriteLine("La Barrio debe contener minimo 1 caracter:");
                Barrio = Console.ReadLine();
            }

            existeBarrio = ValidarBarrio(Barrio);
            while (!existeBarrio) {
                Console.WriteLine("El Barrio ingresado no existe en el sistema, agreguelo antes de ingresar esta vivienda o ingrese otro barrio:");
                Barrio = Console.ReadLine();
                existeBarrio = ValidarBarrio(Barrio);
            }

            //DESCRIPCION
            Console.WriteLine("Ingrese Descripcion:");
            string Descripcion = Console.ReadLine();
            while (Descripcion == "")
            {
                Console.WriteLine("La Descripcion debe contener minimo 1 caracter:");
                Descripcion = Console.ReadLine();
            }

            // NUMERO DE BAÑOS
            int vBanio;
            string vBanioN;
            bool esBanio;
            Console.WriteLine("Ingrese Numero de Baños:");
            vBanioN = Console.ReadLine();
            esBanio = int.TryParse(vBanioN, out vBanio);

            while (!esBanio)
            {
                Console.WriteLine("Debe Ingresar un Numero:");
                vBanioN = Console.ReadLine();
                esBanio = int.TryParse(vBanioN, out vBanio);
            }

            //CANTIDAD DE DORMITORIOS
            int vDormitorio;
            string vDormitorioN;
            bool esDormitorio;
            Console.WriteLine("Ingrese Numero de Dormitorios:");
            vDormitorioN = Console.ReadLine();
            esDormitorio = int.TryParse(vDormitorioN, out vDormitorio);

            while (!esDormitorio)
            {
                Console.WriteLine("Debe Ingresar un Numero de Dormitorios:");
                vDormitorioN = Console.ReadLine();
                esDormitorio = int.TryParse(vDormitorioN, out vDormitorio);
            }

            //CANTIDAD DE METRAJE
            int vMetraje;
            string vMetrajeN;
            int TopeMetraje = repoViv.getTope();
            bool esMetraje;

            bool estaOk = false;

            Console.WriteLine("Ingrese Cantidad de Metros Cuadrados:");
            vMetrajeN = Console.ReadLine();
            esMetraje = int.TryParse(vMetrajeN, out vMetraje);

            while (!esMetraje && estaOk)
            {
                if (!esMetraje) {
                    Console.WriteLine("Debe Ingresar la Cantidad de Metros Cuadrados:");
                    vMetrajeN = Console.ReadLine();
                    esMetraje = int.TryParse(vMetrajeN, out vMetraje);
                }

                if (estaOk) {
                    if( TipoCasa || (vMetraje > TopeMetraje)) {
                        Console.WriteLine("El Metraje no puede superar los " + TopeMetraje + " Metros en viviendas Nuevas :");
                        vMetrajeN = Console.ReadLine();
                        esMetraje = int.TryParse(vMetrajeN, out vMetraje);
                    }
                }
            }

            //CANTIDAD DE AÑOS
            int vAnio;
            string vAnioN;
            bool esAnio;
            Console.WriteLine("Ingrese Año de construccion:");
            vAnioN = Console.ReadLine();
            esAnio = int.TryParse(vAnioN, out vAnio);

            while (!esAnio)
            {
                Console.WriteLine("Debe Ingresar el Año de construccion:");
                vAnioN = Console.ReadLine();
                esAnio = int.TryParse(vAnioN, out vAnio);
            }

            //PRECIO BASE
            //double vPBaseMetro;
            string vPBaseMetroN;

            double outcome;

            Console.WriteLine("Ingrese Precio Base por Metro Cuadrado:");
            vPBaseMetroN = Console.ReadLine();

            while (!double.TryParse(vPBaseMetroN, out outcome) || outcome < 0)
            {
                Console.WriteLine("Debe Ingresar el Precio Base:");
                vPBaseMetroN = Console.ReadLine();
            }

            //AGREGAR VIVIENDA
            AgregarVivienda(TipoCasa, HabilitadaBit, Calle, Numero, Barrio, Descripcion, Int32.Parse(vBanioN), Int32.Parse(vDormitorioN), Int32.Parse(vMetrajeN), Int32.Parse(vAnioN), double.Parse(vPBaseMetroN));

        }

        //MENU ELIMINAR VIVIENDA
        private static void MenuEliminarVivienda() {

            int vId;
            string vIdN;
            bool esId;
            bool existeViv = false;

            Console.Clear();
            Console.WriteLine("Eliminar Vivienda");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese el Id de la vivienda que desea eliminar:");
            vIdN = Console.ReadLine();
            esId = int.TryParse(vIdN, out vId);

            while (!existeViv && !esId) {
                Console.WriteLine("El Id de vivienda no es valido o no existe, intente con otro ID:");
                vIdN = Console.ReadLine();
                esId = int.TryParse(vIdN, out vId);
                if (esId) {
                    existeViv = ValidarVivienda(Convert.ToInt32(vIdN));
                }
            }

            EliminarVivienda(Convert.ToInt32(vIdN));


        }

        //MODIFICAR VIVIENDA
        private static void MenuModificarVivienda() {

            bool TipoCasa = false;
            bool existeBarrio = false;

            int vId;
            string vIdN;
            bool esId;
            bool existeViv = false;

            Console.Clear();
            Console.WriteLine("Modificar Vivienda");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese el Id de la vivienda que desea modificar:");
            vIdN = Console.ReadLine();
            esId = int.TryParse(vIdN, out vId);

            while (!existeViv && !esId)
            {
                Console.WriteLine("El Id de vivienda no es valido o no existe, intente con otro ID:");
                vIdN = Console.ReadLine();
                esId = int.TryParse(vIdN, out vId);
                if (esId)
                {
                    existeViv = ValidarVivienda(Convert.ToInt32(vIdN));
                }
            }

            Console.WriteLine("La vivienda es Nueva(N) o Usada(U)");
            string Tipo = Console.ReadLine();

            while (Tipo != "N" && Tipo != "U" && Tipo != "n" && Tipo != "u")
            {
                Console.WriteLine("Debe seleccionar si la vivienda es Nueva(N) o Usada(U)");
                Console.WriteLine("Ingrese N o U:");
                Tipo = Console.ReadLine();
            }

            if (Tipo == "N")
            {
                TipoCasa = true;
            }
            else if (Tipo == "U")
            {
                TipoCasa = false;
            }

            //HABILITADA
            int HabilitadaBit = 0;
            Console.WriteLine("La vivienda esta habilidada para la venta? (S o N):");
            string Habilitada = Console.ReadLine();
            Habilitada = Habilitada.ToUpper();

            while (Habilitada != "S" && Habilitada != "N")
            {
                Console.WriteLine("Debe ingresar S o N:");
                Habilitada = Console.ReadLine();
            }

            if (Habilitada == "S")
            {
                HabilitadaBit = 1;
            }

            //CALLE
            Console.WriteLine("Ingrese Nombre de Calle:");
            string Calle = Console.ReadLine();

            while (Calle == "")
            {
                Console.WriteLine("La Calle debe contener minimo 1 caracter:");
                Calle = Console.ReadLine();
            }

            //NUMERO DE PUERTA
            Console.WriteLine("Ingrese Numero de puerta:");
            string Numero = Console.ReadLine();
            while (Numero == "")
            {
                Console.WriteLine("Debe Ingresar un Numero de puerta");
                Numero = Console.ReadLine();
            }

            //BARRIO

            Console.WriteLine("Ingrese Barrio:");
            string Barrio = Console.ReadLine();
            while (Barrio == "")
            {
                Console.WriteLine("La Barrio debe contener minimo 1 caracter:");
                Barrio = Console.ReadLine();
            }

            existeBarrio = ValidarBarrio(Barrio);
            while (!existeBarrio)
            {
                Console.WriteLine("El Barrio ingresado no existe en el sistema, agreguelo antes de ingresar esta vivienda o ingrese otro barrio:");
                Barrio = Console.ReadLine();
                existeBarrio = ValidarBarrio(Barrio);
            }

            //DESCRIPCION
            Console.WriteLine("Ingrese Descripcion:");
            string Descripcion = Console.ReadLine();
            while (Descripcion == "")
            {
                Console.WriteLine("La Descripcion debe contener minimo 1 caracter:");
                Descripcion = Console.ReadLine();
            }

            // NUMERO DE BAÑOS
            int vBanio;
            string vBanioN;
            bool esBanio;
            Console.WriteLine("Ingrese Numero de Baños:");
            vBanioN = Console.ReadLine();
            esBanio = int.TryParse(vBanioN, out vBanio);

            while (!esBanio)
            {
                Console.WriteLine("Debe Ingresar un Numero:");
                vBanioN = Console.ReadLine();
                esBanio = int.TryParse(vBanioN, out vBanio);
            }

            //CANTIDAD DE DORMITORIOS
            int vDormitorio;
            string vDormitorioN;
            bool esDormitorio;
            Console.WriteLine("Ingrese Numero de Dormitorios:");
            vDormitorioN = Console.ReadLine();
            esDormitorio = int.TryParse(vDormitorioN, out vDormitorio);

            while (!esDormitorio)
            {
                Console.WriteLine("Debe Ingresar un Numero de Dormitorios:");
                vDormitorioN = Console.ReadLine();
                esDormitorio = int.TryParse(vDormitorioN, out vDormitorio);
            }

            //CANTIDAD DE METRAJE
            int vMetraje;
            string vMetrajeN;
            bool esMetraje;
            Console.WriteLine("Ingrese Cantidad de Metros Cuadrados:");
            vMetrajeN = Console.ReadLine();
            esMetraje = int.TryParse(vMetrajeN, out vMetraje);

            while (!esBanio)
            {
                Console.WriteLine("Debe Ingresar la Cantidad de Metros Cuadrados:");
                vMetrajeN = Console.ReadLine();
                esMetraje = int.TryParse(vMetrajeN, out vMetraje);
            }

            //CANTIDAD DE AÑOS
            int vAnio;
            string vAnioN;
            bool esAnio;
            Console.WriteLine("Ingrese Año de construccion:");
            vAnioN = Console.ReadLine();
            esAnio = int.TryParse(vAnioN, out vAnio);

            while (!esAnio)
            {
                Console.WriteLine("Debe Ingresar el Año de construccion:");
                vAnioN = Console.ReadLine();
                esAnio = int.TryParse(vAnioN, out vAnio);
            }

            //PRECIO BASE
            //double vPBaseMetro;
            string vPBaseMetroN;

            double outcome;

            Console.WriteLine("Ingrese Precio Base por Metro Cuadrado:");
            vPBaseMetroN = Console.ReadLine();

            while (!double.TryParse(vPBaseMetroN, out outcome) || outcome < 0)
            {
                Console.WriteLine("Debe Ingresar el Precio Base:");
                vPBaseMetroN = Console.ReadLine();
            }

            ModificarVivienda(Convert.ToInt32(vIdN), TipoCasa, HabilitadaBit, Calle, Numero, Barrio, Descripcion, Int32.Parse(vBanioN), Int32.Parse(vDormitorioN), Int32.Parse(vMetrajeN), Int32.Parse(vAnioN), double.Parse(vPBaseMetroN));

        }

        //ACCION
        //AGREGAR VIVIENDA
        private static void AgregarVivienda(bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado) {
            if (tipo == true) {
                repoViv.Add(new ViviendaNueva
                {
                    Habilitada = HabilitadaBit,
                    Calle = vCalle,
                    Numero = vNumero,
                    Barrio = vBarrio,
                    Descripcion = vDescripcion,
                    Banios = vBanios,
                    Dormitorios = vDormitorios,
                    Metraje = vMetraje,
                    Anio = vAnio,
                    PBaseXMetroCuadrado = vPBaseXMetroCuadrado
                });
            }
            else {
                repoViv.Add(new ViviendaUsada
                {
                    Habilitada = HabilitadaBit,
                    Calle = vCalle,
                    Numero = vNumero,
                    Barrio = vBarrio,
                    Descripcion = vDescripcion,
                    Banios = vBanios,
                    Dormitorios = vDormitorios,
                    Metraje = vMetraje,
                    Anio = vAnio,
                    PBaseXMetroCuadrado = vPBaseXMetroCuadrado
                });
            }
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Vivienda Agregado");
            DibujarMenu();
        }

        //ELIMINAR VIVIENDA
        private static void EliminarVivienda(int vid) {
            repoViv.Delete(new ViviendaNueva {
                Id = vid
            });
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Vivienda Eliminada");
            ListoVovler();
            DibujarMenu();
        }

        //MODIFICAR VIVIENDA
        private static void ModificarVivienda(int vid, bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado)
        {
            if (tipo == true)
            {
                repoViv.Update(new ViviendaNueva
                {
                    Id = vid,
                    Habilitada = HabilitadaBit,
                    Tipo = "N",
                    Calle = vCalle,
                    Numero = vNumero,
                    Barrio = vBarrio,
                    Descripcion = vDescripcion,
                    Banios = vBanios,
                    Dormitorios = vDormitorios,
                    Metraje = vMetraje,
                    Anio = vAnio,
                    PBaseXMetroCuadrado = vPBaseXMetroCuadrado
                });
            }
            else
            {
                repoViv.Update(new ViviendaUsada
                {
                    Id = vid,
                    Habilitada = HabilitadaBit,
                    Tipo = "U",
                    Calle = vCalle,
                    Numero = vNumero,
                    Barrio = vBarrio,
                    Descripcion = vDescripcion,
                    Banios = vBanios,
                    Dormitorios = vDormitorios,
                    Metraje = vMetraje,
                    Anio = vAnio,
                    PBaseXMetroCuadrado = vPBaseXMetroCuadrado
                });
            }
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Vivienda Actualizada");
            ListoVovler();
            DibujarMenu();
        }

        //LISTAR VIVIENDAS POR BARRIO
        private static void ListarViviendasXBarrio()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Lista de Viviendas por Barrio");
            Console.WriteLine("=================");
            Console.WriteLine("Ingrese Barrio:");
            string Nombre = Console.ReadLine();
            var lista = repoViv.FindByBarrio(Nombre);
            foreach (Vivienda elem in lista)
            {
                Console.WriteLine(elem.Id.ToString() + " - "
                    + elem.Calle.ToString() + " "
                    + elem.Numero.ToString() + ", "
                    + elem.Barrio.ToString()
                    + " - Descripcion: " + elem.Descripcion.ToString()
                    + " - Baños: " + elem.Banios.ToString()
                    + " - Dormitorios: " + elem.Dormitorios.ToString()
                    + " - Metraje: " + elem.Metraje.ToString()
                    + " - Precio Base M2: $ " + elem.PBaseXMetroCuadrado.ToString()
                    + " - Precio final: "
                    + " - Impuestos: "
                    + " - Cuota: "
                );
            }
            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
            PararPantalla();
        }

        //LISTAR VIVIENDAS
        private static void ListarViviendas()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Lista de Viviendas");
            Console.WriteLine("=================");

            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var Lista = client.GetTodasLasViviendas();
                if (Lista != null)
                {
                    foreach (var elem in Lista)
                    {

                        //double resultado = calcularPrecioFinalVivienda("hola", "hola");

                        Console.WriteLine(elem.Id.ToString()
                            + " - " + elem.Calle.ToString()
                            + " - " + elem.Tipo.ToString()
                            + " " + elem.Numero.ToString()
                            + ", " + elem.Barrio.ToString()
                            + " - Descripcion: " + elem.Descripcion.ToString()
                            + " - Baños: " + elem.Banios.ToString()
                            + " - Dormitorios: " + elem.Dormitorios.ToString()
                            + " - Metraje: " + elem.Metraje.ToString()
                            + " - Precio Base M2: $ " + elem.PBaseXMetroCuadrado.ToString()
                            + " - Precio final: " + calcularPrecioFinalVivienda(elem.Metraje.ToString(), elem.PBaseXMetroCuadrado.ToString() , elem.Tipo.ToString())
                            + " - Impuestos: "
                            + " - Cuota: "
                        );
                    }
                }
                else
                {
                    Console.WriteLine("No hay Barrios ingresados:");
                }
            }
            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
        }

        //VALIDAR VIVIENDA
        public static bool ValidarVivienda(int id)
        {
            Vivienda Viv = repoViv.FindById(id);
            if (Viv.Numero != null)
            {
                return true;
            }
            return false;
        }

        //BUSCAR VIVIENDA
        public static Vivienda buscarVivienda(int id) {
            Vivienda Viv = repoViv.FindById(id);
            return Viv;
        }

        //CALCULAR PRECIO FINAL VIVIENDA
        public static decimal calcularPrecioFinalVivienda(string metrosCuadrados, string precioMetroCuadrado, string Tipo)
        {
            decimal precioFinal;

            if (Tipo == "N") {

                decimal ui = decimal.Parse(repoViv.obtenerVariable("ui"));

                //debe retornar el precio en UI
                precioFinal = Convert.ToInt32(metrosCuadrados) * Convert.ToInt32(precioMetroCuadrado);
                precioFinal = precioFinal/ ui;

            }
            else {
                precioFinal = Convert.ToInt32(metrosCuadrados) * Convert.ToInt32(precioMetroCuadrado);
            }

            return Math.Round(precioFinal,2);
        }

        //OBTENER VARIABLE
        //private static string obtenerVariable(string nombre){
        //    string valor = repoViv.obtenerVariable(nombre);
        //    return valor;
        //}
        //

        //------------------------------------------------- USUARIOS
        //MENU
        //MENU AGREGAR USUARIO
        private static void MenuAgregarUsuario() {
            string Email;
            string Password;

            Console.Clear();
            Console.WriteLine("Agregar Usuario");
            Console.WriteLine("=================");

            Console.WriteLine("Ingrese Email:");
            Email = Console.ReadLine();

            bool esmail = validarEmail(Email);

            while (!esmail)
            {
                Console.WriteLine("El Mail debe tener el formato: (nombre@mail.com)");
                Console.WriteLine("Ingrese Email:");
                Email = Console.ReadLine();
            }

            Console.WriteLine("Ingrese Password:");
            Password = Console.ReadLine();

            while (Password == "")
            {
                Console.WriteLine("La Password debe tener al menos 1 caracter");
                Console.WriteLine("Ingrese Password:");
                Email = Console.ReadLine();
            }

            Password = Seguridad.Encriptar(Password);

            AgregarUsuario(Email, Password);
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Usuario Agregado");
            ListoVovler();
        }
        
        //MENU ELIMINAR USUARIO
        private static void MenuEliminarUsuario() {
            string Email;
            int idEmail;
            bool existeEmail = false;

            Console.Clear();
            Console.WriteLine("Eliminar Usuario");
            Console.WriteLine("Ingrese Mail del Usuario a eliminar:");
            Console.WriteLine("=================");
            Email = Console.ReadLine();
            idEmail = buscarUsuarioPorMail(Email);
            if (idEmail != -1)
            {
                existeEmail = true;
            }

            while (!existeEmail) {
                Console.WriteLine("El Usuario ingresado no es correcto o no existe");
                Console.WriteLine("Ingrese Email:");
                Email = Console.ReadLine();
                idEmail = buscarUsuarioPorMail(Email);
                if (idEmail != -1) {
                    existeEmail = true;
                }
            }

            EliminarUsuario(Email);
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Usuario Eliminado");
            ListoVovler();
            

        }

        //MENU MODIFICAR USUARIO
        private static void MenuModificarUsuario() {
            string Email1;
            string Email2;
            string Password;

            bool validaEmail1 = false;
            bool validaEmail2 = false;

            int existeEmail1 = -1;
            
            Console.Clear();
            Console.WriteLine("Modificar Usuario");
            Console.WriteLine("Ingrese Mail del Usuario a modificar:");
            Console.WriteLine("=================");
            Email1 = Console.ReadLine();

            //CONTROLA EL FORMATO DEL MAIL
            validaEmail1 = validarEmail(Email1);
            existeEmail1 = buscarUsuarioPorMail(Email1);

            while (!validaEmail1 && existeEmail1 != -1)
            {
                if (!validaEmail1) {
                    Console.WriteLine("El Mail debe tener el formato: (nombre@mail.com)");
                    Console.WriteLine("Ingrese Email:");
                    Email1 = Console.ReadLine();
                    validaEmail1 = validarEmail(Email1);
                } else {
                    Console.WriteLine("El Usuario ingresado no es correcto o no existe");
                    Console.WriteLine("Ingrese Email:");
                    Email1 = Console.ReadLine();
                    existeEmail1 = buscarUsuarioPorMail(Email1);
                }
            }


            //INGRESA EL NUEVO EMAIL
            Console.WriteLine("Ingrese el Nuevo Mail:");
            Console.WriteLine("=================");
            Email2 = Console.ReadLine();

            validaEmail2 = validarEmail(Email2);

            while (!validaEmail2)
            {   
                Console.WriteLine("El Mail debe tener el formato: (nombre@mail.com)");
                Console.WriteLine("Ingrese Email:");
                Email2 = Console.ReadLine();
                validaEmail2 = validarEmail(Email2);
            }

            //INGRESA EL PASSWORD
            Console.WriteLine("Ingrese Password:");
            Password = Console.ReadLine();

            while (Password == "")
            {
                Console.WriteLine("La Password debe tener al menos 1 caracter");
                Console.WriteLine("Ingrese Password:");
                Password = Console.ReadLine();
            }
            
            Password = Seguridad.Encriptar(Password);

            ModificarUsuario(existeEmail1, Email2, Password);
            Console.WriteLine("//////////////////////////////////////");
            Console.WriteLine("Usuario Modificado");
            ListoVovler();
        }

        //MENU SERVICIO USUARIO
        private static void MenuServicioUsuario()
        {

            Console.Clear();
            Console.WriteLine("Servicio Usuario");
            Console.WriteLine("Ingrese id del Usuario:");
            Console.WriteLine("=================");
            string id = Console.ReadLine();

            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var usuario = client.ObtenerUsuario(Convert.ToInt32(id));

                if (usuario.Email != null)
                {
                    Console.WriteLine("El usuario Existe");
                    Console.WriteLine("Id: " + usuario.id + " Email: " + usuario.Email + " Tipo: " + usuario.Tipo + " Pass: " + usuario.Pass + ".");
                }
                else
                {
                    Console.WriteLine("No FUNCIONA");
                }
                //Usuario unUsu = new Usuario();
                //DTOUsuario DTOUsu = new DTOUsuario();
            }
            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
        }
        
        //BUSCAR USUARIO POR MAIL
        private static int buscarUsuarioPorMail(string emailUsuario){

            Usuario Usu = repoUsu.BuscarUsuarioPorMail(emailUsuario);

            if (Usu.Email != null)
            {
                return Usu.id;
            }
            else {
                return -1;
            }
        }
        
        //VALIDAR EMAIL
        private static bool validarEmail(string email)
        {

            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //ACCION
        //AGREGAR USUARIO
        private static void AgregarUsuario(string vEmail, string vPass) {
            repoUsu.Add(new Usuario
            {
                Tipo = "Administrador",
                Email = vEmail,
                Pass = vPass
            });
        }

        //ELIMINAR USUARIO
        private static void EliminarUsuario(string vEmail) {

            repoUsu.Delete(new Usuario
            {
                Email = vEmail
            });

        }

        //MODIFICAR USUARIO
        private static void ModificarUsuario(int vid, string vEmail, string vPass) {

            repoUsu.Update(new Usuario
            {
                id = vid,
                Email = vEmail,
                Pass = vPass
            });
        }

        //LISTAR USUARIOS
        private static void ListarUsuario()
        {
            Console.WriteLine("=================");
            Console.WriteLine("Lista de Usuarios");
            Console.WriteLine("=================");
            var lista = repoUsu.FindAll();
            using (WcfServicios.WfServiciosClient client = new WcfServicios.WfServiciosClient())
            {
                var ListaUsuarios = client.GetTodosLosUsuarios();
                if (ListaUsuarios != null)
                {
                    foreach (var elem in ListaUsuarios)
                    {
                        Console.WriteLine("Id:" + elem.id.ToString() + " - Mail: " + elem.Email.ToString() + " - Password: " + elem.Pass.ToString());
                    }
                    Console.WriteLine("Lista de Usuarios: " + ListaUsuarios + ".");
                }
                else
                {
                    Console.WriteLine("No hay usuarios ingresados:");
                }
            }
            Console.WriteLine("//////////////////////////////////////");
            ListoVovler();
        }



        //------------------------------------------------- GENERAR ARCHIVOS

        //GENERAR ARCHIVO
        private static void GenerarArchivos() {
            Console.Write(Environment.NewLine);
            Console.Write("GENERAR ARCHIVOS" + Environment.NewLine);
            GenerarArchivoBarrios();
            GenerarArchivoViviendas();
            GenerarArchivoParametros();
            Console.ReadKey();
        }

        //GENERAR ARCHIVO BARRIOS
        private static void GenerarArchivoBarrios()
        {

            string barrios = "";
            string path = "../Barrios.txt";
            IEnumerable<Barrio> ListaBarrios = repoBar.FindAll();

            foreach (Barrio elem in ListaBarrios) {
                barrios += elem.Nombre.ToString() + "#" + elem.Descripcion.ToString() + Environment.NewLine;
            }
            
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                FileStream fs = new FileStream(path, FileMode.Append);
                byte[] bdata = Encoding.Default.GetBytes(barrios);
                fs.Write(bdata, 0, bdata.Length);
                fs.Close();
                Console.Write("Se creo el arhivo Barrios.txt" + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar crear el archivo Barrios.txt", e.ToString());
            }
        }

        //GENERAR ARCHIVO VIVIENDAS
        private static void GenerarArchivoViviendas()
        {
            //Id#calle#numeroPuerta#nombreBarrio#descripcion#baños#dormitorios#metraje#año#preciofinal#tipo#montoContribucion
            string viviendas = "";
            string path = "../Viviendas.txt";
            IEnumerable<Vivienda> ListaViviendas = repoViv.FindAll();

            foreach (Vivienda elem in ListaViviendas)
            {
                viviendas += elem.Id.ToString() + "#"
                          + elem.Numero.ToString() + "#"
                          + elem.Barrio.ToString() + "#"
                          + elem.Descripcion.ToString() + "#"
                          + elem.Banios.ToString() + "#"
                          + elem.Dormitorios.ToString() + "#"
                          + elem.Metraje.ToString() + "#"
                          + elem.Anio.ToString() + "#"
                          + elem.PrecioFinal.ToString() + "#"
                          + elem.Tipo.ToString() + Environment.NewLine;
                          //+ elem.montoContribucion.ToString();
            }

            //viviendas = viviendas.Remove(viviendas.Length - 1);

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                FileStream fs = new FileStream("../Viviendas.txt", FileMode.Append);
                byte[] bdata = Encoding.Default.GetBytes(viviendas);
                fs.Write(bdata, 0, bdata.Length);
                fs.Close();
                Console.Write("Se creo el arhivo Viviendas.txt" + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar crear el archivo Viviendas.txt", e.ToString());
            }
        }

        //GENERAR ARCHIVO PARAMETROS
        private static void GenerarArchivoParametros()
        {
            string parametros = "";
            string path = "../Parametros.txt";
            parametros = repoViv.GetParametros();

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                FileStream fs = new FileStream("../Parametros.txt", FileMode.Append);
                byte[] bdata = Encoding.Default.GetBytes(parametros);
                fs.Write(bdata, 0, bdata.Length);
                fs.Close();
                Console.Write("Se creo el arhivo Parametros.txt" + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar crear el archivo Parametros.txt", e.ToString());
            }
        }

    }
}
