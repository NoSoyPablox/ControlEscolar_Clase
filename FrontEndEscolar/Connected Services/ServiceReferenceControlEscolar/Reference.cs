﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReferenceControlEscolar
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="usuario", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar.Modelo")]
    public partial class usuario : object
    {
        
        private ServiceReferenceControlEscolar.alumno[] alumnoField;
        
        private string apellidoMaternoField;
        
        private string apellidoPaternoField;
        
        private ServiceReferenceControlEscolar.carrera[] carreraField;
        
        private ServiceReferenceControlEscolar.carrera[] carrera1Field;
        
        private string correoInstitucionalField;
        
        private int idUsuarioField;
        
        private string matriculaField;
        
        private string nombreField;
        
        private string numeroTelefonicoField;
        
        private string passwordField;
        
        private string rolField;
        
        private string usernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.alumno[] alumno
        {
            get
            {
                return this.alumnoField;
            }
            set
            {
                this.alumnoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellidoMaterno
        {
            get
            {
                return this.apellidoMaternoField;
            }
            set
            {
                this.apellidoMaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellidoPaterno
        {
            get
            {
                return this.apellidoPaternoField;
            }
            set
            {
                this.apellidoPaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.carrera[] carrera
        {
            get
            {
                return this.carreraField;
            }
            set
            {
                this.carreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.carrera[] carrera1
        {
            get
            {
                return this.carrera1Field;
            }
            set
            {
                this.carrera1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correoInstitucional
        {
            get
            {
                return this.correoInstitucionalField;
            }
            set
            {
                this.correoInstitucionalField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idUsuario
        {
            get
            {
                return this.idUsuarioField;
            }
            set
            {
                this.idUsuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string matricula
        {
            get
            {
                return this.matriculaField;
            }
            set
            {
                this.matriculaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string numeroTelefonico
        {
            get
            {
                return this.numeroTelefonicoField;
            }
            set
            {
                this.numeroTelefonicoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string rol
        {
            get
            {
                return this.rolField;
            }
            set
            {
                this.rolField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string username
        {
            get
            {
                return this.usernameField;
            }
            set
            {
                this.usernameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="alumno", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar.Modelo")]
    public partial class alumno : object
    {
        
        private string apellidoMaternoField;
        
        private string apellidoPaternoField;
        
        private ServiceReferenceControlEscolar.carrera carreraField;
        
        private string correoField;
        
        private System.Nullable<System.DateTime> fechaNacimientoField;
        
        private ServiceReferenceControlEscolar.Binary fotoField;
        
        private int idAlumnoField;
        
        private System.Nullable<int> idCarreraField;
        
        private System.Nullable<int> idTutorField;
        
        private string matriculaField;
        
        private string nombreField;
        
        private ServiceReferenceControlEscolar.usuario usuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellidoMaterno
        {
            get
            {
                return this.apellidoMaternoField;
            }
            set
            {
                this.apellidoMaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string apellidoPaterno
        {
            get
            {
                return this.apellidoPaternoField;
            }
            set
            {
                this.apellidoPaternoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.carrera carrera
        {
            get
            {
                return this.carreraField;
            }
            set
            {
                this.carreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string correo
        {
            get
            {
                return this.correoField;
            }
            set
            {
                this.correoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> fechaNacimiento
        {
            get
            {
                return this.fechaNacimientoField;
            }
            set
            {
                this.fechaNacimientoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.Binary foto
        {
            get
            {
                return this.fotoField;
            }
            set
            {
                this.fotoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idAlumno
        {
            get
            {
                return this.idAlumnoField;
            }
            set
            {
                this.idAlumnoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idCarrera
        {
            get
            {
                return this.idCarreraField;
            }
            set
            {
                this.idCarreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idTutor
        {
            get
            {
                return this.idTutorField;
            }
            set
            {
                this.idTutorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string matricula
        {
            get
            {
                return this.matriculaField;
            }
            set
            {
                this.matriculaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.usuario usuario
        {
            get
            {
                return this.usuarioField;
            }
            set
            {
                this.usuarioField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="carrera", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar.Modelo")]
    public partial class carrera : object
    {
        
        private ServiceReferenceControlEscolar.alumno[] alumnoField;
        
        private string codigoField;
        
        private ServiceReferenceControlEscolar.facultad facultadField;
        
        private int idCarreraField;
        
        private System.Nullable<int> idCoordinadorTutoriasField;
        
        private System.Nullable<int> idFacultadField;
        
        private System.Nullable<int> idJefeCarreraField;
        
        private string nombreField;
        
        private ServiceReferenceControlEscolar.usuario usuarioField;
        
        private ServiceReferenceControlEscolar.usuario usuario1Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.alumno[] alumno
        {
            get
            {
                return this.alumnoField;
            }
            set
            {
                this.alumnoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.facultad facultad
        {
            get
            {
                return this.facultadField;
            }
            set
            {
                this.facultadField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idCarrera
        {
            get
            {
                return this.idCarreraField;
            }
            set
            {
                this.idCarreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idCoordinadorTutorias
        {
            get
            {
                return this.idCoordinadorTutoriasField;
            }
            set
            {
                this.idCoordinadorTutoriasField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idFacultad
        {
            get
            {
                return this.idFacultadField;
            }
            set
            {
                this.idFacultadField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> idJefeCarrera
        {
            get
            {
                return this.idJefeCarreraField;
            }
            set
            {
                this.idJefeCarreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.usuario usuario
        {
            get
            {
                return this.usuarioField;
            }
            set
            {
                this.usuarioField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.usuario usuario1
        {
            get
            {
                return this.usuario1Field;
            }
            set
            {
                this.usuario1Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Binary", Namespace="http://schemas.datacontract.org/2004/07/System.Data.Linq")]
    public partial class Binary : object
    {
        
        private byte[] BytesField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Bytes
        {
            get
            {
                return this.BytesField;
            }
            set
            {
                this.BytesField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="facultad", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar.Modelo")]
    public partial class facultad : object
    {
        
        private ServiceReferenceControlEscolar.carrera[] carreraField;
        
        private int idFacultadField;
        
        private string nombreField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.carrera[] carrera
        {
            get
            {
                return this.carreraField;
            }
            set
            {
                this.carreraField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idFacultad
        {
            get
            {
                return this.idFacultadField;
            }
            set
            {
                this.idFacultadField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nombre
        {
            get
            {
                return this.nombreField;
            }
            set
            {
                this.nombreField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mensaje", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar")]
    public partial class Mensaje : object
    {
        
        private bool errorField;
        
        private string messageField;
        
        private ServiceReferenceControlEscolar.usuario usuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReferenceControlEscolar.usuario usuario
        {
            get
            {
                return this.usuarioField;
            }
            set
            {
                this.usuarioField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/ServiciosLinqEscolar")]
    public partial class CompositeType : object
    {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue
        {
            get
            {
                return this.BoolValueField;
            }
            set
            {
                this.BoolValueField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                this.StringValueField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceControlEscolar.IService1")]
    public interface IService1
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ObtenerUsuarios", ReplyAction="http://tempuri.org/IService1/ObtenerUsuariosResponse")]
        System.Threading.Tasks.Task<ServiceReferenceControlEscolar.usuario[]> ObtenerUsuariosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IniciarSesion", ReplyAction="http://tempuri.org/IService1/IniciarSesionResponse")]
        System.Threading.Tasks.Task<ServiceReferenceControlEscolar.Mensaje> IniciarSesionAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GuardarUsuario", ReplyAction="http://tempuri.org/IService1/GuardarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> GuardarUsuarioAsync(ServiceReferenceControlEscolar.usuario usuarioRegistro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditarUsuario", ReplyAction="http://tempuri.org/IService1/EditarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> EditarUsuarioAsync(ServiceReferenceControlEscolar.usuario usuarioEdicion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EliminarUsuario", ReplyAction="http://tempuri.org/IService1/EliminarUsuarioResponse")]
        System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(int idUsuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ServiceReferenceControlEscolar.CompositeType> GetDataUsingDataContractAsync(ServiceReferenceControlEscolar.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GuardarTutorAcademico", ReplyAction="http://tempuri.org/IService1/GuardarTutorAcademicoResponse")]
        System.Threading.Tasks.Task<bool> GuardarTutorAcademicoAsync(ServiceReferenceControlEscolar.usuario tutorRegistro);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IService1Channel : ServiceReferenceControlEscolar.IService1, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ServiceReferenceControlEscolar.IService1>, ServiceReferenceControlEscolar.IService1
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Service1Client() : 
                base(Service1Client.GetDefaultBinding(), Service1Client.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), Service1Client.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReferenceControlEscolar.usuario[]> ObtenerUsuariosAsync()
        {
            return base.Channel.ObtenerUsuariosAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReferenceControlEscolar.Mensaje> IniciarSesionAsync(string username, string password)
        {
            return base.Channel.IniciarSesionAsync(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> GuardarUsuarioAsync(ServiceReferenceControlEscolar.usuario usuarioRegistro)
        {
            return base.Channel.GuardarUsuarioAsync(usuarioRegistro);
        }
        
        public System.Threading.Tasks.Task<bool> EditarUsuarioAsync(ServiceReferenceControlEscolar.usuario usuarioEdicion)
        {
            return base.Channel.EditarUsuarioAsync(usuarioEdicion);
        }
        
        public System.Threading.Tasks.Task<bool> EliminarUsuarioAsync(int idUsuario)
        {
            return base.Channel.EliminarUsuarioAsync(idUsuario);
        }
        
        public System.Threading.Tasks.Task<ServiceReferenceControlEscolar.CompositeType> GetDataUsingDataContractAsync(ServiceReferenceControlEscolar.CompositeType composite)
        {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public System.Threading.Tasks.Task<bool> GuardarTutorAcademicoAsync(ServiceReferenceControlEscolar.usuario tutorRegistro)
        {
            return base.Channel.GuardarTutorAcademicoAsync(tutorRegistro);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:57866/Service1.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return Service1Client.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return Service1Client.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IService1,
        }
    }
}
