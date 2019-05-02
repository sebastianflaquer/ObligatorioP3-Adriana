using OP3.Dominio.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.Repositorios.Ado
{
    public class RepositorioUsuarioAdo : InterfacesRepositorio.IRepositorioUsuarios
    {
        //ADD - DONE
        public bool Add(Usuario usu)
        {
            return usu != null && usu.Insertar();
        }

        //DELETE - DONE
        public bool Delete(Usuario usu)
        {
            return usu != null && usu.Eliminar();
        }

        //UPDATE - DONE
        public bool Update(Usuario usu)
        {
            return usu != null && usu.Modificar();
        }

        //FINDALL - DONE
        public IEnumerable<Usuario> FindAll()
        {

            //creo la lista
            List<Usuario> lista = new List<Usuario>();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Usuario";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    lista.Add(new Usuario
                    {
                        id = Convert.ToInt32(dr["id"]),
                        Email = dr["Email"].ToString(),
                        Pass = dr["Pass"].ToString()
                    });
                }
            }
            UtilidadesBD.CerrarConexion(cn);
            return lista;

        }

        //VALIDAR USUARIO
        public Usuario validarUsuario(string Email, string Pass){

            bool validarPass = false;
            
            Usuario usu = new Usuario();
            
            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Usuario where Email = @email";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@email", Email));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usu.Email = dr["Email"].ToString();
                    usu.Pass = dr["Pass"].ToString();
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            validarPass = Seguridad.ValidarPass(Pass, usu.Pass);

            if (Email == usu.Email && validarPass)
            {
                return usu;
            }
            else {
                return null;
            }
            
        }

        //BUSCAR USUARIO POR MAIL
        public Usuario BuscarUsuarioPorMail(string emailUsuario)
        {

            Usuario usu = new Usuario();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Usuario where Email = @email";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@email", emailUsuario));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usu.id = Convert.ToInt32(dr["id"]);
                    usu.Email = dr["Email"].ToString();
                    usu.Pass = dr["Pass"].ToString();
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            return usu;
        }

        //FIND BY ID
        public Usuario FindById(int id)
        {
            Usuario usu = new Usuario();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Usuario where id = @id";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    usu.id = Convert.ToInt32(dr["id"]);
                    usu.Email = dr["Email"].ToString();
                    usu.Tipo = dr["Tipo"].ToString();
                    usu.Pass = dr["Pass"].ToString();
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            return usu;
        }

        //FIND BY NAME
        public IEnumerable<Usuario> FindByName(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
