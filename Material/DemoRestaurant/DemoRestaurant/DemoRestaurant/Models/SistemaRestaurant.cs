using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRestaurant.Models
{
    public class SistemaRestaurant
    {
        #region Singleton
        private static readonly SistemaRestaurant sist = new SistemaRestaurant();
        public static SistemaRestaurant LaInstancia { get { return sist; } }
        private SistemaRestaurant()
        {

        }
        #endregion
        #region Declaración de colecciones
        public List<Plato> LosPlatos { get; private set; } = new List<Plato>();

        #endregion
        #region ABM Platos
        public bool AgregarPlato(Plato unPlato)
        {
            if (unPlato != null && !LosPlatos.Contains(unPlato))
            {
                LosPlatos.Add(unPlato);
                return true;
            }
            return false;
        }
        #endregion
        #region Datos de prueba
        public void CargarDatosPrueba()
        {
            AgregarPlato(new Plato("Canelones", "Plato de origen italiano...", 1000M));
            AgregarPlato(new Plato("Milanesa", "Carne frita...", 350M));
            AgregarPlato(new Plato("Papas fritas", "Papas cortadas y fritas...", 80M));
            AgregarPlato(new Plato("Sopa", "Agua caliente con sal ...", 120M));
            AgregarPlato(new Plato("Arroz", "Arroz blanco...", 350M));
        }
        #endregion
    }
}