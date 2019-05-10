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

        //LISTAR VIVIENDAS POR BARRIO
        public IEnumerable<DTOVivienda> BuscarViviendaPorBarrios(string nombreBarrio)
        {
            IEnumerable<Vivienda> ListaViviendas = repoViv.FindAll();

            if (ListaViviendas != null)
            {
                List<DTOVivienda> losViviendas = new List<DTOVivienda>();
                foreach (Vivienda viv in ListaViviendas)
                {
                    if (viv.Barrio == nombreBarrio)
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
                }
                return losViviendas;
            }
            else {
                return null;
            }
        }

        //AGREGAR USUARIO
        public DTOVivienda AgregarVivienda(bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado)
        {
            bool agrego;

            if (tipo == true)
            {
                agrego = repoViv.Add(new ViviendaNueva
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
            else
            {
                agrego = repoViv.Add(new ViviendaUsada
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

            if (agrego)
            {
                DTOVivienda DTOviv = new DTOVivienda
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
                };

                return DTOviv;
            }
            else
            {
                return null;
            }
        }

        //MODIFICAR USUARIO                     
        public DTOVivienda ModificarVivinda(int vid, bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado)
        {
            bool modifico;

            if (tipo == true)
            {
                modifico = repoViv.Update(new ViviendaNueva
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
                modifico = repoViv.Update(new ViviendaUsada
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


            if (modifico)
            {
                DTOVivienda DTOviv = new DTOVivienda
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
                };

                return DTOviv;
            }
            else
            {
                return null;
            }
        }

        //ELIMINAR USUARIO
        public DTOVivienda EliminarVivienda(int vid)
        {
            bool elimino;
            elimino = repoViv.Delete(new ViviendaNueva{

                Id = vid
            });

            if (elimino) {
                DTOVivienda DTOviv = new DTOVivienda{
                    Id = vid
                };
                return DTOviv;

            } else {
                return null;
            }
        }

        //BUSCAR POR ID
        public DTOVivienda FindById(int vid)
        {
            var encontro = repoViv.FindById(vid);
            if (encontro != null){
                DTOVivienda DTOviv = new DTOVivienda
                {
                    Habilitada = encontro.Habilitada,
                    Calle = encontro.Calle,
                    Numero = encontro.Numero,
                    Barrio = encontro.Barrio,
                    Descripcion = encontro.Descripcion,
                    Banios = encontro.Banios,
                    Dormitorios = encontro.Dormitorios,
                    Metraje = encontro.Metraje,
                    Anio = encontro.Anio,
                    PBaseXMetroCuadrado = encontro.PBaseXMetroCuadrado
                };
                return DTOviv;
            }
            else
            {
                return null;
            }
        }

        //TIENE VIVIENDA
        public bool tieneVivienda(string nombre)
        {
            var encontro = repoViv.tieneVivienda(nombre);
            if (encontro)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //OBTENER VARIABLES
        public string obtenerVariable(string nombre) {
            var variable = repoViv.obtenerVariable(nombre);
            return variable;
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

        //BUSCAR BARRIO POR NOMBRE
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
        
        //AGREGAR USUARIO
        public DTOBarrio AgregarBarrio(string vNombre, string vDescripcion)
        {
            bool agrego = repoBar.Add(new Barrio
            {   
                Nombre = vNombre,
                Descripcion = vDescripcion
            });


            if (agrego)
            {
                DTOBarrio DTObar = new DTOBarrio
                {
                    Nombre = vNombre,
                    Descripcion = vDescripcion
                };

                return DTObar;
            }
            else {
                return null;
            }
        }

        //MODIFICAR USUARIO
        public DTOBarrio ModificarBarrio(string nombre, string descripcion)
        {
            bool modifico = repoBar.Update(new Barrio
            {
                Descripcion = descripcion,
                Nombre = nombre
            });


            if (modifico)
            {
                DTOBarrio DTObar = new DTOBarrio
                {
                    Nombre = nombre,
                    Descripcion = descripcion
                };

                return DTObar;
            }
            else
            {
                return null;
            }
        }

        //ELIMINAR USUARIO
        public DTOBarrio EliminarBarrio(string vNombre)
        {
            bool elimino = repoBar.Delete(new Barrio
            {
                Nombre = vNombre
            });

            if (elimino)
            {
                DTOBarrio DTObar = new DTOBarrio
                {
                    Nombre = vNombre
                };

                return DTObar;
            }
            else
            {
                return null;
            }
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

        //AGREGAR USUARIO
        public DTOUsuario AgregarUsuario()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR USUARIO
        public DTOUsuario ModificarUsuario()
        {
            throw new NotImplementedException();
        }

        //ELIMINAR USUARIO
        public DTOUsuario EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
