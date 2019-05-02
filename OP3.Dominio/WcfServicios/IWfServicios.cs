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
        [OperationContract]
        DTOUsuario ObtenerUsuario(int id);

        [OperationContract]
        IEnumerable<DTOUsuario> GetTodosLosUsuarios();

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
