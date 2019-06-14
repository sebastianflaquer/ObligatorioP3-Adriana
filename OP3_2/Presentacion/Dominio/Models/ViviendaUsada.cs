using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    [Table("Vivienda Usada")]
    public class ViviendaUsada : Vivienda
    {

        public decimal Contribucion { get; set; }
    }
}