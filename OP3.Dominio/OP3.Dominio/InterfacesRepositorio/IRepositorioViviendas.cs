using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.InterfacesRepositorio
{
    public interface IRepositorioViviendas{

        bool Add(Vivienda viv);
        bool Delete(Vivienda viv);
        bool Update(Vivienda viv);
        Vivienda FindById(int Nombre);
        IEnumerable<Vivienda> FindAll();
        IEnumerable<Vivienda> FindByName(string nom);

    }
}
