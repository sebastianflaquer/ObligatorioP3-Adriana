using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuarios
    {
        bool Add(Usuario usu);
        bool Delete(Usuario usu);
        bool Update(Usuario usu);
        Usuario FindById(int Id);
        IEnumerable<Usuario> FindAll();
        IEnumerable<Usuario> FindByName(string nom);
        Usuario validarUsuario(string Email, string Pass);
        Usuario BuscarUsuarioPorMail(string emailUsuario);
    }
}
