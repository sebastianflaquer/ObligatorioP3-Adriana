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

        //CALCULAR NUMEROS VIVIENDA
        internal int calcularNumerosVivienda() {

            //cotizacionUI = valor#cotizacionUSD=valor#topeMts=valor#plazoNueva=valor#plazoUsada=valor           
            //monto final
            //cf = c(1+i)*t
            //cf = C(1 + i)*t;
            //CALCULO
            //t = this.AniosFinanciacionVivN; // 5 años
            //i = this.TasaInteres / 100;

            //CALCULO


            //string porcentajeInteres = obtenerVariable("Interes Anual");
            double resInteres = 8 / 100;

            //calcular Monto interes Compuesto

            //cf = PrecioFinal x(1 + resInteres);


            //VIVIENDA NUEVA
            //Precio base en pesos
            //En unidades indexadas y la cotizacion es una dato en la base
            //Las viviendas nuevas debeern tener un tope de metraje (tambien es un dato en la base y hay que chekear)
            //Maximo 2 años de antiguedad


            //VIVIENDA USADA
            //Precio final en dolares. la cotizacion es contra la UI, tambien es una variable en la base. 
            //Pagan un porcentaje de impuestos tambien se define en una variable. es un porcentaje
            //Monto de contribucion inmobiliaria


            //Por ejemplo, el monto con intereses para un capital de 1200000 que se pague al cabo de 5 años y a una
            //tasa de interés compuesto anual del 8 %, se calculará:
            //i = 8 / 100 = 0,08
            //t = 5
            //C = 120000
            //por lo tanto Cf = 120000 x(1 + 0, 08) 5

            return 10;
        }

        
    }
}
