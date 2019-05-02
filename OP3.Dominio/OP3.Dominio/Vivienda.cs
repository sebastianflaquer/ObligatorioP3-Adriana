using OP3.Dominio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio
{
    public abstract class Vivienda{

        public int Id { get; set; } //identificador de Vivienda
        public abstract string Tipo {get; set;}
        public int Habilitada { get; set;}
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Barrio { get; set; }
        public string Descripcion { get; set; }
        public int Banios { get; set; }
        public int Dormitorios { get; set; }
        public int Metraje { get; set; }
        public int Anio { get; set; }
        public double PBaseXMetroCuadrado { get; set; }
        public double PrecioFinal { get; set; }

        //datos
        public double CotizacionUI = 4.1566;
        public int TopMetraje = 120;
        public double TasaInteres = 8;
        public int MaxAniosViviendasNuevas = 2;
        public int AniosFinanciacionVivN = 5;
        public int AniosFinanciacionVivU = 10;

        //INSERTAR VIVIENDA
        internal virtual bool Insertar()
        {
            throw new NotImplementedException();
        }

        //MODIFICAR VIVIENDA - DONE
        internal virtual bool Modificar(){

            SqlConnection cn = Utilidades.UtilidadesBD.CrearConexion();

            //CREA LA TRANSACCION
            SqlTransaction trn = null;

            try
            {
                //string cadenaComando = @"UPDATE Vivienda SET Habilitada = @Habilitada, Tipo = @Tipo, Calle = @Calle, Numero = @Numero, Barrio = @Barrio, Descripcion = @Descripcion, Banios = @Banios, Dormitorios = @Dormitorios, Metraje = @Metraje, Anio = @Anio, PBaseXMetroCuadrado = @PBaseXMetroCuadrado WHERE Id = @id";
                string cadenaComando = @"UPDATE Vivienda SET Calle = @Calle WHERE Id = @id";

                //crea el sqlcommand
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrega los parametros
                cmd.Parameters.Add(new SqlParameter("@Habilitada", this.Habilitada));
                cmd.Parameters.Add(new SqlParameter("@Tipo", this.Tipo));
                cmd.Parameters.Add(new SqlParameter("@Calle", this.Calle));
                cmd.Parameters.Add(new SqlParameter("@Numero", this.Numero));
                cmd.Parameters.Add(new SqlParameter("@Barrio", this.Barrio));
                cmd.Parameters.Add(new SqlParameter("@Descripcion", this.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@Banios", this.Banios));
                cmd.Parameters.Add(new SqlParameter("@Dormitorios", this.Dormitorios));
                cmd.Parameters.Add(new SqlParameter("@Metraje", this.Metraje));
                cmd.Parameters.Add(new SqlParameter("@Anio", this.Anio));
                cmd.Parameters.Add(new SqlParameter("@PBaseXMetroCuadrado", this.PBaseXMetroCuadrado));

                cmd.Parameters.Add(new SqlParameter("@id", this.Id));
                string texto = "UPDATE Vivienda SET Habilitada =" + this.Habilitada + ", Tipo = " + this.Tipo + ", Calle =" + this.Calle + ", Numero = " + this.Numero + ", Barrio = " + this.Barrio + ", Descripcion = " + this.Descripcion + ", Banios = " + this.Banios + ", Dormitorios =" + this.Dormitorios + ", Metraje =" + this.Metraje + ", Anio =" + this.Anio + ", PBaseXMetroCuadrado =" + this.PBaseXMetroCuadrado + " WHERE Id =" + this.Id + ";";  

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

        //ELIMINAR VIVIENDA - DONE
        internal virtual bool Eliminar(){

            //CREO LA CONEXION
            SqlConnection cn = UtilidadesBD.CrearConexion();

            //CREO LA TRANSACCION
            SqlTransaction trn = null;

            try
            {
                string cadenaComando = @"DELETE FROM Vivienda WHERE Id= @id; ";

                //crea el sql command
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrego los parametros
                cmd.Parameters.Add(new SqlParameter("@id", this.Id));

                //abro la conexion
                UtilidadesBD.AbrirConexion(cn);

                //ejecuto la transaccion
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

    }
}
