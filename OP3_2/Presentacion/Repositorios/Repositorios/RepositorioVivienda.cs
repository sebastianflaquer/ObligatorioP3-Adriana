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


        public bool Add(Vivienda vivienda)
        {
            db.Viviendas.Add(vivienda);
            db.SaveChanges();

            return true;
        }

        public bool Delete(Vivienda vivienda)
        {
            db.Viviendas.Remove(vivienda);
            db.SaveChanges();

            return true;
        }

        public IEnumerable<Vivienda> FindAll()
        {
            List<Vivienda> listaViviendas = db.Viviendas.ToList();

            return listaViviendas;
        }

        public Vivienda FindById(int? id)
        {
            Vivienda viv = db.Viviendas.Where(v => v.Id == id).FirstOrDefault();
            return viv;
        }

        public bool Update(Vivienda vivienda)
        {
            db.Entry(vivienda).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        //AGREGAR LISTA VIVIENDAS
        public void AgregarListaVivienda(List<Vivienda> listaVivienda) {

            foreach (Vivienda viv in listaVivienda) {

                //validar si no existe esa vivienda
                var existe = db.Viviendas.Where(v => v.Id == viv.Id).FirstOrDefault();

                //validar que sea valido
                bool esValido = ValidarVivienda(viv);
                
                if (existe == null && esValido) {
                    db.Viviendas.Add(viv);
                    db.SaveChanges();
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
                var validarBar = db.Barrios.Where(b => b.Nombre == viv.Barrio).FirstOrDefault();
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
            bool tipoValido = ValidarTextos(viv.Tipo, 1, 50);
            bool montoContribucionValido = ValidarEnteros(viv.Contribucion);

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