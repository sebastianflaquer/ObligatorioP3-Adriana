using OP3.Dominio.Repositorios.Ado;
using OP3.Dominio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio
{
    public class ViviendaNueva : Vivienda{


        public override string Tipo { get; set;}

        


        //INSERTAR VIVIENDA NUEVA - DONE
        internal override bool Insertar()
        {

            SqlConnection cn = Utilidades.UtilidadesBD.CrearConexion();

            //CREA LA TRANSACCION
            SqlTransaction trn = null;

            try
            {
                string cadenaComando = @"INSERT INTO Vivienda VALUES(@Habilitada,'N', @Calle, @Numero, @Barrio, @Descripcion, @Banios, @Dormitorios, @Metraje, @Anio, @PBaseXMetroCuadrado, @PrecioFinal);";

                //crea el sqlcommand
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrega los parametros
                cmd.Parameters.Add(new SqlParameter("@Habilitada", this.Habilitada));
                cmd.Parameters.Add(new SqlParameter("@Calle", this.Calle));
                cmd.Parameters.Add(new SqlParameter("@Numero", this.Numero));
                cmd.Parameters.Add(new SqlParameter("@Barrio", this.Barrio));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Banios", this.Banios));
                cmd.Parameters.Add(new SqlParameter("@Dormitorios", this.Dormitorios));
                cmd.Parameters.Add(new SqlParameter("@Metraje", this.Metraje));
                cmd.Parameters.Add(new SqlParameter("@Anio", this.Anio));
                cmd.Parameters.Add(new SqlParameter("@PBaseXMetroCuadrado", this.PBaseXMetroCuadrado));
                cmd.Parameters.Add(new SqlParameter("@PrecioFinal", this.ClalcularPrecioFinal()));

                //abre la conexion
                UtilidadesBD.AbrirConexion(cn);

                //inicia la transaccion
                trn = cn.BeginTransaction();

                //asigno la transaccion
                cmd.Transaction = trn;
                cmd.ExecuteNonQuery();

                trn.Commit();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex);
                trn.Rollback();
                return false;
            }
            finally
            {
                UtilidadesBD.CerrarConexion(cn);
            }
        }
        
        //CALCULAR PRECIO FINAL
        internal double ClalcularPrecioFinal() {
            double precioFinal;
            precioFinal = this.Metraje * this.PBaseXMetroCuadrado;
            return precioFinal;
        }
        
    }
}
