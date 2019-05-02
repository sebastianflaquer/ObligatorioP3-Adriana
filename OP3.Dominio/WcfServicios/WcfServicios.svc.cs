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
