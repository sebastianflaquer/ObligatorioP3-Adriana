using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Models;
using DAL;
using System.Data.Entity;

namespace Dominio.Repositorios
{
    public class RepositorioVivienda
    {

        private OP3_2Context db = new OP3_2Context();
        RepositorioBarrio repoBar = new RepositorioBarrio();


        public IEnumerable<string> ListaEstados(){

            List<string> listaEstados = new List<string>();

            listaEstados.Add("Habilitada");
            listaEstados.Add("Inhabilitada");

            return listaEstados;
        }



        //ADD
        public bool Add(Vivienda vivienda)
        {
            db.Viviendas.Add(vivienda);
            db.SaveChanges();

            return true;
        }

        //DELETE
        public bool Delete(Vivienda vivienda)
        {
            db.Viviendas.Remove(vivienda);
            db.SaveChanges();

            return true;
        }

        //FIND ALL
        public IEnumerable<Vivienda> FindAll()
        {
            List<Vivienda> listaViviendas = db.Viviendas.ToList();


            return listaViviendas;
        }

        //FIND ALL
        public IEnumerable<ViviendaNueva> FindAllNuevas()
        {
            Parametro paraAnios = db.Parametros.Where(p => p.Nombre == "plazoUsada").FirstOrDefault();
            int anios = Convert.ToInt32(paraAnios.Valor);

            Parametro paraMoneda = db.Parametros.Where(p => p.Nombre == "cotizacionUI").FirstOrDefault();
            int moneda = Convert.ToInt32(paraMoneda.Valor);

            List<ViviendaNueva> listaViviendas = db.ViviendasNueva.ToList();
            foreach (var viv in listaViviendas)
            {
                viv.calcValorCuota(anios, moneda);
                viv.CantCuotas = (anios * 12);
            }

            return listaViviendas;
        }

        //FIND ALL
        public IEnumerable<ViviendaUsada> FindAllUsadas()
        {
            Parametro paraAnios = db.Parametros.Where(p => p.Nombre == "plazoUsada").FirstOrDefault();
            int anios = Convert.ToInt32(paraAnios.Valor);

            Parametro paraMoneda = db.Parametros.Where(p => p.Nombre == "cotizacionUSD").FirstOrDefault();
            int moneda = Convert.ToInt32(paraMoneda.Valor);

            List<ViviendaUsada> listaViviendas = db.ViviendasUsada.ToList();
            foreach (var viv in listaViviendas)
            {
                viv.calcValorCuota(anios, moneda);
                viv.CantCuotas = (anios * 12);
            }

            return listaViviendas;
        }

        //FINDBYID
        public Vivienda FindById(int? id)
        {
            Vivienda viv = db.Viviendas.Where(v => v.Id == id).FirstOrDefault();
            return viv;
        }


        ////////////////////////////////////////////////////////////////////////////
        //  BUSCAR POR

        

        //BUSCAR VIVIENDAS POR DORMITORIOS
        public List<Vivienda> buscarViviendasPorDormitorios(string cantDorm)
        {

            List<Vivienda> listaViviendas = new List<Vivienda>();
            int cantidad = Convert.ToInt32(cantDorm);


            listaViviendas = db.Viviendas.Where(v => v.Dormitorios == cantidad).ToList();

            return listaViviendas;
        }

        //BUSCAR VIVIENDAS POR RANGO
        public List<Vivienda> buscarViviendasPorRango(decimal rangoMin, decimal rangoMax)  
        {
            List<Vivienda> listaViviendas = new List<Vivienda>();
            listaViviendas = db.Viviendas.Where(v => v.PrecioFinal >= rangoMin && v.PrecioFinal <= rangoMax).ToList();
            return listaViviendas;
        }


        //BUSCAR VIVIENDAS POR BARRIO
        public List<Vivienda> buscarViviendasPorBarrio(string nombreBarrio)
        {

            List<Vivienda> listaViviendas = new List<Vivienda>();

            listaViviendas = db.Viviendas.Where(v => v.Barrio.Nombre == nombreBarrio).ToList();

            return listaViviendas;
        }

        //BUSCAR VIVIENDAS POR ESTADO
        public List<Vivienda> buscarViviendasPorEstado(string estado)
        {

            List<Vivienda> listaViviendas = new List<Vivienda>();

            listaViviendas = db.Viviendas.Where(v => v.Estado == estado).ToList();

            return listaViviendas;
        }

        //BUSCAR VIVIENDAS NUEVAS
        public List<ViviendaNueva> buscarViviendasNuevas(string tipo)
        {
            //buscarViviendasNuevas();
            List<ViviendaNueva> listaViviendas = new List<ViviendaNueva>();
            listaViviendas = db.ViviendasNueva.ToList();

            return listaViviendas;
        }

        //BUSCAR VIVIENDAS USADAS
        public List<ViviendaUsada> buscarViviendasUsadas(string tipo)
        {   
            List<ViviendaUsada> listaViviendas = new List<ViviendaUsada>();
            listaViviendas = db.ViviendasUsada.ToList();

            return listaViviendas;
        }

        //UPDATE
        public bool Update(Vivienda vivienda)
        {
            db.Entry(vivienda).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        //LEER ARCHIVO VIVIENDAS REPO
        public void leerArchivoViviendasRepo(List<string> linesViviendas) {
            List<Vivienda> listaViviendas = new List<Vivienda>();
            foreach (var line in linesViviendas)
            {
                string[] entries = line.Split('#');
                ViviendaNueva vivN = new ViviendaNueva();
                ViviendaUsada vivU = new ViviendaUsada();
                if (entries[10].ToString() == "N")
                {
                    string nombreBarrio = entries[3].ToString();
                    //Barrio bar = new Barrio();
                    Barrio bar = repoBar.FindByName(nombreBarrio);

                    vivN.Id = Convert.ToInt32(entries[0]);
                    vivN.Estado = "Recibida";
                    vivN.Calle = entries[1].ToString();
                    vivN.Numero = entries[2].ToString();
                    vivN.Barrio = bar; //entries[3].ToString();
                    vivN.Descripcion = entries[4].ToString();
                    vivN.Banios = Convert.ToInt32(entries[5].ToString());
                    vivN.Dormitorios = Convert.ToInt32(entries[6]);
                    vivN.Metraje = Convert.ToInt32(entries[7]);
                    vivN.Anio = Convert.ToInt32(entries[8]);
                    vivN.PrecioFinal = Convert.ToDecimal(entries[9]);
                    vivN.Tipo = entries[10];
                    Vivienda vivEncontrada = FindById(vivN.Id);

                    listaViviendas.Add(vivN);

                }
                else {
                    string nombreBarrio = entries[3].ToString();
                    //Barrio bar = new Barrio();
                    Barrio bar = repoBar.FindByName(nombreBarrio);

                    vivU.Id = Convert.ToInt32(entries[0]);
                    vivU.Estado = "Recibida";
                    vivU.Calle = entries[1].ToString();
                    vivU.Numero = entries[2].ToString();
                    vivU.Barrio = bar; //entries[3].ToString();
                    vivU.Descripcion = entries[4].ToString();
                    vivU.Banios = Convert.ToInt32(entries[5].ToString());
                    vivU.Dormitorios = Convert.ToInt32(entries[6]);
                    vivU.Metraje = Convert.ToInt32(entries[7]);
                    vivU.Anio = Convert.ToInt32(entries[8]);
                    vivU.PrecioFinal = Convert.ToDecimal(entries[9]);
                    vivU.Tipo = entries[10];
                    vivU.Contribucion = Convert.ToDecimal(entries[11]);

                    Vivienda vivEncontrada = FindById(vivU.Id);

                    listaViviendas.Add(vivU);
                }
                // 0   1       2            3              4       5        6        7      8      9        10      11
                //Id#calle#numeroPuerta#nombreBarrio#descripcion#baños#dormitorios#metraje#año#preciofinal#tipo#montoContribucion
                //CARGA EL BARRIO
            }
            AgregarListaVivienda(listaViviendas);
        }



        //AGREGAR LISTA VIVIENDAS
        public void AgregarListaVivienda(List<Vivienda> listaVivienda) {

            using (var db = new OP3_2Context())
            {
                foreach (Vivienda viv in listaVivienda)
                {

                    //validar si no existe esa vivienda
                    var existe = db.Viviendas.Where(v => v.Id == viv.Id).FirstOrDefault();

                    //validar que sea valido
                    bool esValido = ValidarVivienda(viv);

                    if (existe == null && esValido)
                    {
                        Barrio bar = db.Barrios.Find(viv.Barrio.Id);
                        viv.Barrio = bar;
                        //db.Entry(viv.Barrio).State = EntityState.Modified;
                        //db.Barrios.Attach(viv.Barrio);
                        db.Viviendas.Add(viv);
                        db.SaveChanges();
                    }
                }
            }
        }

        //VALIDAR VIVIENDAS
        public bool ValidarVivienda(Vivienda viv)
        {
            bool esValido = false;

            // 0   1       2            3              4       5        6        7      8      9        10      11
            //Id#calle#numeroPuerta#nombreBarrio#descripcion#baños#dormitorios#metraje#año#preciofinal#tipo#montoContribucion

            bool calleValido = ValidarTextos(viv.Calle, 3, 50);
            bool numeroPuertaValido = ValidarTextos(viv.Numero, 1, 50);

            bool nombreBarrioValido = false;
            if (viv.Barrio != null) {
                var validarBar = db.Barrios.Where(b => b.Nombre == viv.Barrio.Nombre).FirstOrDefault();
                if (validarBar != null)
                {
                    nombreBarrioValido = true;
                }
            }

            bool descripcionValido = ValidarTextos(viv.Descripcion, 3, 250);
            bool baniosValido = true;//ValidarEnteros(viv.Banios);
            bool dormitoriosValido = ValidarEnteros(viv.Dormitorios);
            bool metrajeValido = ValidarEnteros(viv.Metraje);
            bool precioFinalValido = ValidarEnteros(viv.PrecioFinal);
            bool tipoValido = true;//ValidarTextos(viv.Tipo, 1, 50);
            bool montoContribucionValido = true;//ValidarEnteros(viv.Contribucion);

            if (calleValido && numeroPuertaValido && nombreBarrioValido && descripcionValido && baniosValido && dormitoriosValido && metrajeValido && precioFinalValido && tipoValido && montoContribucionValido) {
                esValido = true;
            }

            return esValido;
        }

        //AGREGAR LISTA PARAMETROS
        public void AgregarListaParametros(List<Parametro> listaParametro)
        {
            foreach (Parametro par in listaParametro)
            {
                //valida que exista
                var existe = db.Parametros.Where(p => p.Nombre == par.Nombre).FirstOrDefault();
                //valida que sea valido
                bool esValido = ValidarParametro(par);

                if (existe == null && esValido)
                {
                    db.Parametros.Add(par);
                    db.SaveChanges();
                }
            }
        }

        //VALIDAR PARAMETRO
        private bool ValidarParametro(Parametro par)
        {
            bool esValido = false;

            bool nombreValido = ValidarTextos(par.Nombre, 3, 50);

            if (nombreValido) {
                esValido = true;
            }

            return esValido;
        }

        //BUSCAR PARAMETRO POR NOMBRE
        public Parametro FindByParametroName(string nombre)
        {
            Parametro par = db.Parametros.Where(p => p.Nombre == nombre).FirstOrDefault();
            return par;
        }

        //VALIDAR TEXTO
        public bool ValidarTextos(string texto, int min, int max)
        {
            bool esValido = false;

            if (texto.Length >= min && texto.Length <= max)
            {
                esValido = true;
            }
            return esValido;
        }

        //int
        public bool ValidarEnteros(int entero)
        {
            bool esValido = false;

            if (entero >= 0 && entero <= int.MaxValue)
            {
                esValido = true;
            }
            return esValido;
        }

        //double
        public bool ValidarEnteros(double entero)
        {
            bool esValido = false;

            if (entero >= 0 && entero <= double.MaxValue)
            {
                esValido = true;
            }
            return esValido;
        }

        //double
        public bool ValidarEnteros(decimal entero)
        {
            bool esValido = false;

            if (entero >= 0 && entero <= decimal.MaxValue)
            {
                esValido = true;
            }
            return esValido;
        }

        //DISPOSE
        public void Dispose()
        {
            db.Dispose();
        }
    }
}