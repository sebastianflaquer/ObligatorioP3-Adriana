using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dominio.Models
{
    [Table("Viviendas")]
    public abstract class Vivienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } //identificador de Vivienda

        //[DataType(DataType.Text.Equals{Recibida”, “Habilitada”, “Inhabilitada” o “Sorteada})]
        public string Estado { get; set; }

        public string Tipo { get; set; }

        [MaxLength(50)]
        public string Calle { get; set; }

        [MaxLength(50)]
        public string Numero { get; set; }

        public virtual Barrio Barrio { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        public int Banios { get; set; }
        
        public int Dormitorios { get; set; }
        
        public int Metraje { get; set; }
        
        public int Anio { get; set; }
        
        public decimal PrecioFinal { get; set; }

        [NotMapped]
        public decimal ValorCuota{ get; set; }
        [NotMapped]
        public int CantCuotas { get; set; }
        
        //CALCULAR VALOR CUOTA
        public decimal calcValorCuota(int anios, decimal moneda) {

            this.ValorCuota = PrecioFinal / (anios * 12);
            this.ValorCuota = ValorCuota * moneda;
            this.ValorCuota = Math.Round(ValorCuota);
            
            return ValorCuota;
        }

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