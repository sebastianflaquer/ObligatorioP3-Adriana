using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using OP3.Dominio.Utilidades;

namespace OP3.Dominio
{
    public class Barrio{

        public string Nombre { get; set; } //identificador del Barrio
        public string Descripcion { get; set; }

        //INSERTAR BARRIO
        internal bool Insertar(){

            SqlConnection cn = Utilidades.UtilidadesBD.CrearConexion();

            //CREA LA TRANSACCION
            SqlTransaction trn = null;

            try
            {
                
                string cadenaComando = @"INSERT INTO Barrio VALUES(@nombre,@descripcion);";

                //crea el sqlcommand
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrega los parametros
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));

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
            catch( Exception ex)
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

        //ELIMINAR BARRIO
        internal bool Eliminar(){

            //CREO LA CONEXION
            SqlConnection cn = UtilidadesBD.CrearConexion();

            //CREO LA TRANSACCION
            SqlTransaction trn = null;

            try
            {
                string cadenaComando = @"DELETE FROM Barrio WHERE Nombre= @nombre; ";

                //crea el sql command
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrego los parametros
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));

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
            catch(Exception ex)
            {
                Console.WriteLine("Error: ", ex);
                trn.Rollback();
                return false;
            }
            finally {
                UtilidadesBD.CerrarConexion(cn);
            }
        }

        //MODIFICAR BARRIO
        internal bool Modificar(){

            // CREO LA CONEXION Y LA TRANSACCION
            SqlConnection cn = UtilidadesBD.CrearConexion();
            SqlTransaction trn = null;

            try {

                string cadenaCommando = @"UPDATE Barrio set Descripcion = @descripcion WHERE Nombre = @nombre";

                //crea el sql command
                SqlCommand cmd = new SqlCommand(cadenaCommando, cn);

                //agrego los parametros
                cmd.Parameters.Add(new SqlParameter("@nombre", this.Nombre));
                cmd.Parameters.Add(new SqlParameter("@descripcion", this.Descripcion));

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
            catch (Exception ex) {
                Console.WriteLine("Error: ", ex);
                trn.Rollback();
                return false;
            }
            finally {
                UtilidadesBD.CerrarConexion(cn);
            }
        }

    }
}
