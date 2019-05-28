using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    [Table("Viviendas")]
    public class Vivienda
    {
        [Key]
        public int Id { get; set; } //identificador de Vivienda
        public string Tipo { get; set; }
        public int Habilitada { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public Barrio Barrio { get; set; }
        public string Descripcion { get; set; }
        public string Banios { get; set; }
        public int Dormitorios { get; set; }
        public int Metraje { get; set; }
        public int Anio { get; set; }
        public double PBaseXMetroCuadrado { get; set; }
        public double PrecioFinal { get; set; }
        public double Contribucion { get; set; }

        //INSERTAR VIVIENDA
        internal virtual bool Insertar()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR VIVIENDA - DONE
        internal virtual bool Modificar()
        {
            throw new NotImplementedException();
        }

        //ELIMINAR VIVIENDA - DONE
        internal virtual bool Eliminar()
        {
            throw new NotImplementedException();
        }
    }
}