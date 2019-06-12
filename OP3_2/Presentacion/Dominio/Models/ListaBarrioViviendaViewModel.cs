using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    public class ListaBarrioViviendaViewModel
    {
        public IEnumerable<Vivienda> viviendas { get; set;}
        public IEnumerable<Barrio> barrios { get; set;}

    }
}