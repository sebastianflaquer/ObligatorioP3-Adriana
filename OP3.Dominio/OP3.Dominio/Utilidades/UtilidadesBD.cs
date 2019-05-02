using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OP3.Dominio.Utilidades
{
    class UtilidadesBD
    {

        //STRING CADENA DE CONEXION
        //private static string cadenaConexion = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private static string cadenaConexion = @"SERVER=.;DATABASE=ObligatorioP3;INTEGRATED SECURITY=TRUE;";

        //CREAR CONEXION
        public static SqlConnection CrearConexion() {
            return new SqlConnection(cadenaConexion);
        }

        //CERRAR CONEXION
        public static bool CerrarConexion(SqlConnection cn) {
            if (cn.State == System.Data.ConnectionState.Open) {
                cn.Close();
                return true;
            }
            return false;
        }

        //ABRIR CONEXION
        public static bool AbrirConexion(SqlConnection cn){
            if (cn.State == System.Data.ConnectionState.Closed) {
                cn.Open();
                return true;
            }
            return true;
        }

    }
}
