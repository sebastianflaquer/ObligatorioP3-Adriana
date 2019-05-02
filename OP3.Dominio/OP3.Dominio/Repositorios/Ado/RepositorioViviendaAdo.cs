using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OP3.Dominio.Utilidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP3.Dominio.Repositorios.Ado
{
    public class RepositorioViviendaAdo : InterfacesRepositorio.IRepositorioViviendas
    {

        //VARIABLES
        public int TopMetraje = 120;

        //AGREGAR VIVIENDA - DONE
        public bool Add(Vivienda viv)
        {
            return viv != null && viv.Insertar();
        }

        //ELIMINAR VIVIENDA - DONE
        public bool Delete(Vivienda viv)
        {
            return viv != null && viv.Eliminar();
        }

        //ACTUALIZAR VIVIENDA - DONE
        public bool Update(Vivienda viv)
        {
            return viv != null && viv.Modificar();
        }

        //BUSCAR TODAS LAS VIVIENDAS - DONE
        public IEnumerable<Vivienda> FindAll(){
            //creo la lista
            List<Vivienda> lista = new List<Vivienda>();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Vivienda";

            SqlCommand cmd = new SqlCommand(consulta, cn);

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string T = dr["Tipo"].ToString();

                    if (T == "N")
                    {
                        lista.Add(new ViviendaNueva
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Tipo = dr["Tipo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Numero = dr["Numero"].ToString(),
                            Barrio = dr["Barrio"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Banios = Convert.ToInt32(dr["Banios"]),
                            Dormitorios = Convert.ToInt32(dr["Dormitorios"]),
                            Metraje = Convert.ToInt32(dr["Metraje"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            PBaseXMetroCuadrado = Convert.ToInt32(dr["PBaseXMetroCuadrado"])
                        });
                    }
                    else
                    {
                        lista.Add(new ViviendaUsada
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Tipo = dr["Tipo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Numero = dr["Numero"].ToString(),
                            Barrio = dr["Barrio"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Banios = Convert.ToInt32(dr["Banios"]),
                            Dormitorios = Convert.ToInt32(dr["Dormitorios"]),
                            Metraje = Convert.ToInt32(dr["Metraje"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            PBaseXMetroCuadrado = Convert.ToInt32(dr["PBaseXMetroCuadrado"])
                        });
                    }
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            return lista;
        }

        //BUSCAR VIVIENDA POR BARRIO - DONE
        public IEnumerable<Vivienda> FindByBarrio(string NombreBarrio){

            //creo la lista
            List<Vivienda> lista = new List<Vivienda>();

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Vivienda where barrio = @barrio";


            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@barrio", NombreBarrio));


            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string T = dr["Tipo"].ToString();

                    if (T == "N")
                    {
                        lista.Add(new ViviendaNueva
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Tipo = dr["Tipo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Numero = dr["Numero"].ToString(),
                            Barrio = dr["Barrio"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Banios = Convert.ToInt32(dr["Banios"]),
                            Dormitorios = Convert.ToInt32(dr["Dormitorios"]),
                            Metraje = Convert.ToInt32(dr["Metraje"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            PBaseXMetroCuadrado = Convert.ToInt32(dr["PBaseXMetroCuadrado"])
                        });
                    }
                    else
                    {
                        lista.Add(new ViviendaUsada
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Tipo = dr["Tipo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Numero = dr["Numero"].ToString(),
                            Barrio = dr["Barrio"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Banios = Convert.ToInt32(dr["Banios"]),
                            Dormitorios = Convert.ToInt32(dr["Dormitorios"]),
                            Metraje = Convert.ToInt32(dr["Metraje"]),
                            Anio = Convert.ToInt32(dr["Anio"]),
                            PBaseXMetroCuadrado = Convert.ToInt32(dr["PBaseXMetroCuadrado"])
                        });
                    }
                }
            }

            UtilidadesBD.CerrarConexion(cn);
            return lista;
        }

        //TIENE VIVIENDA - DONE
        public bool tieneVivienda(string NombreBarrio) {

            //creo la lista
            Vivienda Viv = new ViviendaNueva();
            bool existe = false;

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Vivienda where barrio = @barrio";
            
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@barrio", NombreBarrio));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Viv.Id = Convert.ToInt32(dr["Id"]);
                    Viv.Calle = dr["Calle"].ToString();
                    Viv.Numero = dr["Numero"].ToString();
                    Viv.Barrio = dr["Barrio"].ToString();
                    Viv.Descripcion = dr["Descripcion"].ToString();
                    Viv.Banios = Convert.ToInt32(dr["Banios"]);
                    Viv.Dormitorios = Convert.ToInt32(dr["Dormitorios"]);
                    Viv.Metraje = Convert.ToInt32(dr["Metraje"]);
                    Viv.Anio = Convert.ToInt32(dr["Anio"]);
                    Viv.PBaseXMetroCuadrado = Convert.ToDouble(dr["PBaseXMetroCuadrado"]);
                }
                existe = true;
            }
            else {
                existe = false;
            }

            UtilidadesBD.CerrarConexion(cn);
            
            return existe;

        }

        //FIND BY ID
        public Vivienda FindById(int Id)
        {
            Vivienda VivN = new ViviendaNueva();
            Vivienda VivU = new ViviendaUsada();
            bool esnueva = false;

            SqlConnection cn = UtilidadesBD.CrearConexion();
            string consulta = @"SELECT * FROM Vivienda where Id = @id";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.Add(new SqlParameter("@id", Id));

            UtilidadesBD.AbrirConexion(cn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr["Tipo"].ToString() == "N") {
                        esnueva = true;
                        VivN.Id = Convert.ToInt32(dr["Id"]);
                        VivN.Habilitada = Convert.ToInt32(dr["Habilitada"]);
                        VivN.Tipo = dr["Id"].ToString();
                        VivN.Calle = dr["Calle"].ToString();
                        VivN.Numero = dr["Numero"].ToString();
                        VivN.Barrio = dr["Barrio"].ToString();
                        VivN.Descripcion = dr["Descripcion"].ToString();
                        VivN.Banios = Convert.ToInt32(dr["Banios"]);
                        VivN.Dormitorios = Convert.ToInt32(dr["Dormitorios"]);
                        VivN.Metraje = Convert.ToInt32(dr["Metraje"]);
                        VivN.Anio = Convert.ToInt32(dr["Anio"]);
                        VivN.PBaseXMetroCuadrado = Convert.ToDouble(dr["PBaseXMetroCuadrado"]);
                    } else {
                        esnueva = false;
                        VivU.Id = Convert.ToInt32(dr["Id"]);
                        VivN.Habilitada = Convert.ToInt32(dr["Habilitada"]);
                        VivN.Tipo = dr["Id"].ToString();
                        VivU.Calle = dr["Calle"].ToString();
                        VivU.Numero = dr["Numero"].ToString();
                        VivU.Barrio = dr["Barrio"].ToString();
                        VivU.Descripcion = dr["Descripcion"].ToString();
                        VivU.Banios = Convert.ToInt32(dr["Banios"]);
                        VivU.Dormitorios = Convert.ToInt32(dr["Dormitorios"]);
                        VivU.Metraje = Convert.ToInt32(dr["Metraje"]);
                        VivU.Anio = Convert.ToInt32(dr["Anio"]);
                        VivU.PBaseXMetroCuadrado = Convert.ToDouble(dr["PBaseXMetroCuadrado"]);
                    }
                    
                }
            }

            if (esnueva)
            {
                return VivN;
            }
            else {
                return VivU;
            }
        }

        //FIND BY ID
        public IEnumerable<Vivienda> FindByName(string nom)
        {
            throw new NotImplementedException();
        }

        //GET TOPE
        public int getTope()
        {
            return this.TopMetraje;
        }

        ////GET COTIZACION UI
        //public double getCotizacionUI()
        //{
        //    return this.CotizacionUI;
        //}

        ////GET MAX ANIOSVivN
        //public int getMaxAnionsVivN() {
        //    return this.MaxAniosViviendasNuevas;
        //}

        //CALCULA COSTO VIVIENDA
        public string CalcularCostoVivienda(Vivienda Viv) {
            string retorno = "";

            //CALCULA EL PRECIO DE LA VIVIENDA
            return retorno;
        }

    }
}
