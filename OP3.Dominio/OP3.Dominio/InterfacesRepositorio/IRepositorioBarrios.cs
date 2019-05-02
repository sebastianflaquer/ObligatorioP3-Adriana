using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.InterfacesRepositorio
{
    public interface IRepositorioBarrios{

        bool Add(Barrio bar);
        bool Delete(Barrio bar);
        bool Update(Barrio bar);
        Barrio FindById(string Nombre);
        IEnumerable<Barrio> FindAll();
        IEnumerable<Barrio> FindByName(string nom);

    }
}
