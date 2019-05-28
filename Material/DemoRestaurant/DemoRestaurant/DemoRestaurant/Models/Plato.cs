using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRestaurant.Models
{
    public class Plato : IEquatable<Plato>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public bool Equals(Plato other)
        {
            return other != null && this.Nombre.ToUpper().Trim() ==
                other.Nombre.ToUpper().Trim();
        }
        public Plato()
        {

        }
        public Plato(string nom, string desc, decimal precio)
        {
            Nombre = nom; Descripcion = desc; Precio = precio;
        }

        internal bool EsValido()
        {
            return !string.IsNullOrEmpty(this.Nombre) && 
                this.Precio > 0 && this.Precio < 3000 && 
                !string.IsNullOrEmpty(this.Descripcion);
        }
        public override string ToString()
        {
            return this.Nombre + " - " + this.Descripcion + " - $ " + this.Precio;
        }
    }
}