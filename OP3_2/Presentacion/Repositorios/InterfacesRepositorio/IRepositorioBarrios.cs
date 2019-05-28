using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioBarrios
    {
        bool Add(Barrio bar);
        bool Delete(Barrio bar);
        bool Update(Barrio bar);
        Barrio FindById(int? id);
        Barrio FindByName(string nombre);
        IEnumerable<Barrio> FindAll();
    }
}
