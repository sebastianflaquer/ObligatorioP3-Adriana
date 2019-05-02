using OP3.Dominio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio
{
    public class Usuario: IActiveRecord 
    {
        public int id { get; set; }
        public string Tipo { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public bool Insertar()
        {

            SqlConnection cn = Utilidades.UtilidadesBD.CrearConexion();
            //SqlConnection cn = Utilidades.UtilidadesBD.CrearConexion();

            //CREA LA TRANSACCION
            SqlTransaction trn = null;
            
            try
            {
                string cadenaComando = @"INSERT INTO usuario VALUES(@tipo, @email, @password);";

                //crea el sqlcommand
                SqlCommand cmd = new SqlCommand(cadenaComando, cn);

                //agrega los parametros
                cmd.Parameters.Add(new SqlParameter("@tipo", this.Tipo));
                cmd.Parameters.Add(new SqlParameter("@email", this.Email));
                cmd.Parameters.Add(new SqlParameter("@password", this.Pass));

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
            catch(SqlException ex){
                Debug.Assert(false, "Error al intentar guardar el usuario." + ex.Message);
                return false;
            }
            finally {
                Utilidades.UtilidadesBD.CerrarConexion(cn);
            }
        }

        private bool Validar()
        {
            Usuario Usu = new Usuario();
            
            Usu.Email = this.Email;
            Usu.Pass = this.Pass;

            return true;
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }
    }
}
