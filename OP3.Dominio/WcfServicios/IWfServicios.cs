using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWfServicios
    {

        ////////////////////////////////////////
        //USUARIOS
        [OperationContract]
        DTOUsuario ObtenerUsuario(int id);

        [OperationContract]
        IEnumerable<DTOUsuario> GetTodosLosUsuarios();

        [OperationContract]
        DTOUsuario AgregarUsuario();

        [OperationContract]
        DTOUsuario ModificarUsuario();

        [OperationContract]
        DTOUsuario EliminarUsuario(int id);



        ////////////////////////////////////////
        //BARRIOS
        [OperationContract]
        IEnumerable<DTOBarrio> GetTodosLosBarrios();

        [OperationContract]
        DTOBarrio BuscarBarrioPorNombre(string nombre);

        [OperationContract]
        DTOBarrio AgregarBarrio(string nombre, string descripcion);

        [OperationContract]
        DTOBarrio ModificarBarrio(string nombre, string descripcion);

        [OperationContract]
        DTOBarrio EliminarBarrio(string nombre);
        
        ////////////////////////////////////////
        //VIVIENDAS
        [OperationContract]
        IEnumerable<DTOVivienda> GetTodasLasViviendas();

        [OperationContract]
        DTOVivienda AgregarVivienda(bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado);

        [OperationContract]
        DTOVivienda ModificarVivinda(int vid, bool tipo, int HabilitadaBit, string vCalle, string vNumero, string vBarrio, string vDescripcion, int vBanios, int vDormitorios, int vMetraje, int vAnio, double vPBaseXMetroCuadrado);

        [OperationContract]
        DTOVivienda EliminarVivienda(int id);
        
    }

    [DataContract]
    public class DTOUsuario
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Pass { get; set; }
    }

    [DataContract]
    public class DTOBarrio
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }

    [DataContract]
    public class DTOVivienda
    {
        [DataMember]
        public int Id { get; set; } //identificador de Vivienda
        [DataMember]
        public string Tipo { get; set; }
        [DataMember]
        public int Habilitada { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Barrio { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember] 
        public int Banios { get; set; }
        [DataMember]
        public int Dormitorios { get; set; }
        [DataMember]
        public int Metraje { get; set; }
        [DataMember]
        public int Anio { get; set; }
        [DataMember]
        public double PBaseXMetroCuadrado { get; set; }
        [DataMember]
        public double PrecioFinal { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
