﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OP3.Presentacion.WcfServicios {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTOUsuario", Namespace="http://schemas.datacontract.org/2004/07/WcfServicios")]
    [System.SerializableAttribute()]
    public partial class DTOUsuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PassField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pass {
            get {
                return this.PassField;
            }
            set {
                if ((object.ReferenceEquals(this.PassField, value) != true)) {
                    this.PassField = value;
                    this.RaisePropertyChanged("Pass");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tipo {
            get {
                return this.TipoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoField, value) != true)) {
                    this.TipoField = value;
                    this.RaisePropertyChanged("Tipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTOBarrio", Namespace="http://schemas.datacontract.org/2004/07/WcfServicios")]
    [System.SerializableAttribute()]
    public partial class DTOBarrio : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTOVivienda", Namespace="http://schemas.datacontract.org/2004/07/WcfServicios")]
    [System.SerializableAttribute()]
    public partial class DTOVivienda : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AnioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BaniosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BarrioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CalleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DormitoriosField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HabilitadaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MetrajeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PBaseXMetroCuadradoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PrecioFinalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Anio {
            get {
                return this.AnioField;
            }
            set {
                if ((this.AnioField.Equals(value) != true)) {
                    this.AnioField = value;
                    this.RaisePropertyChanged("Anio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Banios {
            get {
                return this.BaniosField;
            }
            set {
                if ((this.BaniosField.Equals(value) != true)) {
                    this.BaniosField = value;
                    this.RaisePropertyChanged("Banios");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Barrio {
            get {
                return this.BarrioField;
            }
            set {
                if ((object.ReferenceEquals(this.BarrioField, value) != true)) {
                    this.BarrioField = value;
                    this.RaisePropertyChanged("Barrio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Calle {
            get {
                return this.CalleField;
            }
            set {
                if ((object.ReferenceEquals(this.CalleField, value) != true)) {
                    this.CalleField = value;
                    this.RaisePropertyChanged("Calle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Dormitorios {
            get {
                return this.DormitoriosField;
            }
            set {
                if ((this.DormitoriosField.Equals(value) != true)) {
                    this.DormitoriosField = value;
                    this.RaisePropertyChanged("Dormitorios");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Habilitada {
            get {
                return this.HabilitadaField;
            }
            set {
                if ((this.HabilitadaField.Equals(value) != true)) {
                    this.HabilitadaField = value;
                    this.RaisePropertyChanged("Habilitada");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Metraje {
            get {
                return this.MetrajeField;
            }
            set {
                if ((this.MetrajeField.Equals(value) != true)) {
                    this.MetrajeField = value;
                    this.RaisePropertyChanged("Metraje");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Numero {
            get {
                return this.NumeroField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroField, value) != true)) {
                    this.NumeroField = value;
                    this.RaisePropertyChanged("Numero");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PBaseXMetroCuadrado {
            get {
                return this.PBaseXMetroCuadradoField;
            }
            set {
                if ((this.PBaseXMetroCuadradoField.Equals(value) != true)) {
                    this.PBaseXMetroCuadradoField = value;
                    this.RaisePropertyChanged("PBaseXMetroCuadrado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PrecioFinal {
            get {
                return this.PrecioFinalField;
            }
            set {
                if ((this.PrecioFinalField.Equals(value) != true)) {
                    this.PrecioFinalField = value;
                    this.RaisePropertyChanged("PrecioFinal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tipo {
            get {
                return this.TipoField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoField, value) != true)) {
                    this.TipoField = value;
                    this.RaisePropertyChanged("Tipo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfServicios.IWfServicios")]
    public interface IWfServicios {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/ObtenerUsuario", ReplyAction="http://tempuri.org/IWfServicios/ObtenerUsuarioResponse")]
        OP3.Presentacion.WcfServicios.DTOUsuario ObtenerUsuario(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/ObtenerUsuario", ReplyAction="http://tempuri.org/IWfServicios/ObtenerUsuarioResponse")]
        System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOUsuario> ObtenerUsuarioAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodosLosUsuarios", ReplyAction="http://tempuri.org/IWfServicios/GetTodosLosUsuariosResponse")]
        OP3.Presentacion.WcfServicios.DTOUsuario[] GetTodosLosUsuarios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodosLosUsuarios", ReplyAction="http://tempuri.org/IWfServicios/GetTodosLosUsuariosResponse")]
        System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOUsuario[]> GetTodosLosUsuariosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodosLosBarrios", ReplyAction="http://tempuri.org/IWfServicios/GetTodosLosBarriosResponse")]
        OP3.Presentacion.WcfServicios.DTOBarrio[] GetTodosLosBarrios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodosLosBarrios", ReplyAction="http://tempuri.org/IWfServicios/GetTodosLosBarriosResponse")]
        System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOBarrio[]> GetTodosLosBarriosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodasLasViviendas", ReplyAction="http://tempuri.org/IWfServicios/GetTodasLasViviendasResponse")]
        OP3.Presentacion.WcfServicios.DTOVivienda[] GetTodasLasViviendas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWfServicios/GetTodasLasViviendas", ReplyAction="http://tempuri.org/IWfServicios/GetTodasLasViviendasResponse")]
        System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOVivienda[]> GetTodasLasViviendasAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWfServiciosChannel : OP3.Presentacion.WcfServicios.IWfServicios, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WfServiciosClient : System.ServiceModel.ClientBase<OP3.Presentacion.WcfServicios.IWfServicios>, OP3.Presentacion.WcfServicios.IWfServicios {
        
        public WfServiciosClient() {
        }
        
        public WfServiciosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WfServiciosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WfServiciosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WfServiciosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OP3.Presentacion.WcfServicios.DTOUsuario ObtenerUsuario(int id) {
            return base.Channel.ObtenerUsuario(id);
        }
        
        public System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOUsuario> ObtenerUsuarioAsync(int id) {
            return base.Channel.ObtenerUsuarioAsync(id);
        }
        
        public OP3.Presentacion.WcfServicios.DTOUsuario[] GetTodosLosUsuarios() {
            return base.Channel.GetTodosLosUsuarios();
        }
        
        public System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOUsuario[]> GetTodosLosUsuariosAsync() {
            return base.Channel.GetTodosLosUsuariosAsync();
        }
        
        public OP3.Presentacion.WcfServicios.DTOBarrio[] GetTodosLosBarrios() {
            return base.Channel.GetTodosLosBarrios();
        }
        
        public System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOBarrio[]> GetTodosLosBarriosAsync() {
            return base.Channel.GetTodosLosBarriosAsync();
        }
        
        public OP3.Presentacion.WcfServicios.DTOVivienda[] GetTodasLasViviendas() {
            return base.Channel.GetTodasLasViviendas();
        }
        
        public System.Threading.Tasks.Task<OP3.Presentacion.WcfServicios.DTOVivienda[]> GetTodasLasViviendasAsync() {
            return base.Channel.GetTodasLasViviendasAsync();
        }
    }
}
