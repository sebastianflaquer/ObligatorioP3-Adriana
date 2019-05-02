using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OP3.Dominio.Utilidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.Repositorios.Ado{

    public class RepositorioBarrioAdo : InterfacesRepositorio.IRepositorioBarrios
    {
        //ADD - DONE
        public bool Add(Barrio bar){
            return bar != null && bar.Insertar();
        }

        //DELETE - DONE
        public bool Delete(Barrio bar){
            return bar != null && bar.Eliminar();
        }

        //UPDATE - DONE
        public bool Update(Barrio bar){
            return bar != null && bar.Modificar();
        }

        //FINDALL - DONE
        public IEnumerable<Barrio> FindAll(){

            //creo la lista
            List<Barrio> lista = new List<Barrio>();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM BARRIO";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) {
                while (dr.Read()) {
                    lista.Add(new Barrio
                    {
                        Nombre = dr["Nombre"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
            }
            UtilidadesBD.CerrarConexion(cn);
            return lista;

        }

        //FINDBYID - DONE
        public Barrio FindById(string Nombre){

            Barrio bar = new Barrio(); 

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM BARRIO where Nombre = @nombre";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    bar.Nombre = dr["Nombre"].ToString();
                    bar.Descripcion = dr["Descripcion"].ToString();
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            return bar;
        }

        //FINDBYNAME
        public IEnumerable<Barrio> FindByName(string nom){

            throw new NotImplementedException();
        }
    }
}
