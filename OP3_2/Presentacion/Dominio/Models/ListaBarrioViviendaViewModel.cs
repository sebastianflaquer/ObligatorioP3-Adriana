using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    public class ListaBarrioViviendaViewModel
    {
        public IEnumerable<ViviendaNueva> viviendasNuevas { get; set;}
        public IEnumerable<ViviendaUsada> viviendasUsadas { get; set; }
        public IEnumerable<Barrio> barrios { get; set;}

    }
}