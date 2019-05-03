using OP3.Dominio;
using OP3.Dominio.InterfacesRepositorio;
using OP3.Dominio.Repositorios.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WcfServicios : IWfServicios
    {

        IRepositorioBarrios repoBar = new RepositorioBarrioAdo();
        IRepositorioViviendas repoViv = new RepositorioViviendaAdo();
        IRepositorioUsuarios repoUsu = new RepositorioUsuarioAdo();

        //VIVIENDAS
        //////////////////////////////////////////////////////////////////////////////////////////
        //LISTAR TODAS LAS VIVIENDAS
        public IEnumerable<DTOVivienda> GetTodasLasViviendas()
        {
            IEnumerable<Vivienda> ListaViviendas = repoViv.FindAll();

            if (ListaViviendas != null)
            {
                List<DTOVivienda> losViviendas = new List<DTOVivienda>();
                foreach (Vivienda viv in ListaViviendas)
                {
                    losViviendas.Add(new DTOVivienda
                    {   
                        Id = viv.Id,
                        Tipo = viv.Tipo,
                        Habilitada = viv.Habilitada,
                        Calle = viv.Calle,
                        Numero = viv.Numero,
                        Barrio = viv.Barrio,
                        Descripcion = viv.Descripcion,
                        Banios = viv.Banios,
                        Dormitorios = viv.Dormitorios,
                        Metraje = viv.Metraje,
                        Anio = viv.Anio,
                        PBaseXMetroCuadrado = viv.PBaseXMetroCuadrado,
                        PrecioFinal = viv.PrecioFinal
                    });
                }
                return losViviendas;
            }
            return null;
        }
        
        //BARRIOS
        //////////////////////////////////////////////////////////////////////////////////////////

        //LISTAR TODOS LOS BARRIOS
        public IEnumerable<DTOBarrio> GetTodosLosBarrios()
        {
            IEnumerable<Barrio> ListaBarrios = repoBar.FindAll();

            if (ListaBarrios != null)
            {
                List<DTOBarrio> losBarrios = new List<DTOBarrio>();
                foreach (Barrio bar in ListaBarrios)
                {
                    losBarrios.Add(new DTOBarrio
                    {
                        Nombre = bar.Nombre,
                        Descripcion = bar.Descripcion
                    });
                }
                return losBarrios;
            }
            return null;
        }

        public DTOBarrio BuscarBarrioPorNombre(string nombre) {

            var barrrio = repoBar.FindById(nombre);
            if (barrrio != null)
            {

                DTOBarrio DTObar = new DTOBarrio
                {
                    Nombre = barrrio.Nombre,
                    Descripcion = barrrio.Descripcion
                };
                return DTObar;
            }
            else {
                return null;
            }
        }
        
        public DTOBarrio AgregarUsuario()
        {
            throw new NotImplementedException();
        }

        public DTOBarrio ModificarUsuario()
        {
            throw new NotImplementedException();
        }

        public DTOBarrio EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }


        //USUARIOS
        //////////////////////////////////////////////////////////////////////////////////////////

        //LISTAR TODOS LOS USUARIOS
        public IEnumerable<DTOUsuario> GetTodosLosUsuarios()
        {
            IEnumerable<Usuario> ListaUsuarios = repoUsu.FindAll();

            if (ListaUsuarios != null)
            {
                List<DTOUsuario> losUsuarios = new List<DTOUsuario>();
                foreach (Usuario usu in ListaUsuarios)
                {
                    losUsuarios.Add(new DTOUsuario
                    {
                        id = usu.id,
                        Email = usu.Email,
                        Tipo = usu.Tipo,
                        Pass = usu.Pass
                    });
                }
                return losUsuarios;
            }
            return null;
        }

        //OBTENER USUARIO POR ID
        public DTOUsuario ObtenerUsuario(int id)
        {
            IRepositorioUsuarios repoUsu = new RepositorioUsuarioAdo();
            Usuario unUsu = repoUsu.FindById(id);

            DTOUsuario DTOUsu = new DTOUsuario
            {
                id = unUsu.id,
                Email = unUsu.Email,
                Tipo = unUsu.Tipo,
                Pass = unUsu.Pass
            };

            return DTOUsu;

        }

        
    }
}
