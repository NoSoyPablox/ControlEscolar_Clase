﻿using ServiciosLinqEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosLinqEscolar
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<usuario> ObtenerUsuarios();

        [OperationContract]
        Mensaje IniciarSesion(string username, string password);

        [OperationContract]
        Boolean GuardarUsuario(usuario usuarioRegistro);
        [OperationContract]
        Boolean EditarUsuario(usuario usuarioEdicion);
        [OperationContract]
        Boolean EliminarUsuario(int idUsuario);


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //Aqui van los metodos del proyecto
        [OperationContract]
        bool GuardarTutorAcademico(usuario tutorRegistro);

        [OperationContract]
        List<alumno> ObtenerEstudiantesPorTutor(int idTutor);

        [OperationContract]
        bool RegistrarFechasSesionTutoria();


        [OperationContract]
        List<periodoEscolar> ObtenerPeriodosEscolares();

        [OperationContract]
        List<alumno> obtenerAlumnos();


        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
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
