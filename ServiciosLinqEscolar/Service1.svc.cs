using ServiciosLinqEscolar.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosLinqEscolar
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public List<usuario> ObtenerUsuarios()
        {
            List<usuario> usuarioBD = UsuarioDAO.obtenerUsuarios();
            return usuarioBD;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool GuardarUsuario(usuario usuarioRegistro)
        {
            return UsuarioDAO.guardarUsuario(usuarioRegistro);
        }

        public Mensaje IniciarSesion(string username, string password)
        {
            return UsuarioDAO.iniciarSesion(username, password);
        }

        public bool EditarUsuario(usuario usuarioEdicion)
        {
            return UsuarioDAO.editarUsuario(usuarioEdicion);
        }

        public bool EliminarUsuario(int idUsuario)
        {
            return UsuarioDAO.eliminarUsuario(idUsuario);
        }

        //Aqui van los metodos del proyecto
        public bool GuardarTutorAcademico(usuario tutorRegistro)
        {
            return UsuarioDAO.guardarTutorAcademico(tutorRegistro);
        }

        public List<alumno> ObtenerEstudiantesPorTutor(int idTutor)
        {
            return AlumnoDAO.obtenerAlumnosPorTutor(idTutor);
        }

        public List<periodoEscolar> ObtenerPeriodosEscolares()
        {
            return PeriodoEscolarDAO.obtenerPeriodosEscolares();
        }

        public List<alumno> obtenerAlumnos()
        {
            return AlumnoDAO.obtenerAlumnos();
        }

        public bool RegistrarFechasSesionTutoria(string fechaSesion1, string fechaSesion2, string fechaSesion3, int idPeriodoEscolar)
        {
            return TutoriaDAO.registrarFechasSesionTutoria( fechaSesion1,  fechaSesion2, fechaSesion3,  idPeriodoEscolar);
        }
        public List<usuario> ObtenerTutores()
        {
            return UsuarioDAO.obtenerTutores();
        }

        public bool AsignarTutorAlumno(int idAlumno, int idTutor)
        {
            return AlumnoDAO.asignarTutorAlumno(idAlumno, idTutor);
        }

        public List<tutoria> ObtenerTutoriasPorPeriodoEscolar(int idPeriodoEscolar)
        {
            return TutoriaDAO.obtenerTutoriasPorPeriodoEscolar(idPeriodoEscolar);
        }

        public bool RegistrarFechaCierreATutoriasPeriodoEscolar(int idTutoria1, string fechaInicio1, string fechaCierre1, int idTutoria2, string fechaInicio2, string fechaCierre2, int idTutoria3, string fechaInicio3, string fechaCierre3)
        {
            return TutoriaDAO.registrarFechaCierreATutoriasPeriodoEscolar(idTutoria1, fechaInicio1 ,fechaCierre1, idTutoria2, fechaInicio2 ,fechaCierre2, idTutoria3, fechaInicio3 ,fechaCierre3);
        }

        public bool VerificarFechaCierreVigente(int idTutoria)
        {
            return TutoriaDAO.verificarFechaCierreVigente(idTutoria);
        }

        public bool VerificarRegistroReportePorTutoria(int idTutoria, int idTutor)
        {
            return ReporteDeTutoriaDAO.verificarRegistroPorReporteDeTutoria(idTutoria, idTutor);
        }

        public bool RegistarListaAsistenciaAReporte(int idReporte, List<int> idAsistentes, List<int> idNoAsistentes)
        {
            return ListaAsistenciaDAO.registrarListaAsistenciaAReporte(idReporte, idAsistentes, idNoAsistentes);
        }

        public bool RegistrarReporteTutoria(string comentariosGenerales, int numeroSesion, int idTutor, int idTutoria)
        {
            return ReporteDeTutoriaDAO.registrarReporteTutoria(comentariosGenerales, numeroSesion, idTutor, idTutoria);
        }

        public reporteDeTutoria ObtenerReporteCreado(int idTutoria, int idTutor)
        {
            return ReporteDeTutoriaDAO.obtenerReporteCreado(idTutoria, idTutor);
        }
        public bool RegistrarProblematicasAcademicas(List<problematicaAcademica> listaProblematicas, int idReporte)
        {
            return ProblematicaAcademicaDAO.registrarProblematicasAcademicas(listaProblematicas, idReporte);
        }

        public List<reporteDeTutoria> ObtenerReportesPorTutor(int idTutor)
        {
            return ReporteDeTutoriaDAO.obtenerReportesPorTutor(idTutor);
        }

        public List<alumno> ObtenerAsistentesPorReporte(int idReporte)
        {
            return ListaAsistenciaDAO.obtenerAsistentesPorReporte(idReporte);
        }

        public List<alumno> ObtenerNoAsistentesPorReporte(int idReporte)
        {
            return ListaAsistenciaDAO.obtenerNoAsistentesPorReporte(idReporte);
        }

        public List<problematicaAcademica> ObtenerProblematicasSinSolucion()
        {
            return ProblematicaAcademicaDAO.obtenerProblematicasSinSolucion();
        }

        public bool registrarSolucionAProblematica(solucionProblematica solucionProblematica1 ,int idProblematica)
        {
            return SolucionAProblematicaDAO.registrarSolucionAProblematica(solucionProblematica1, idProblematica);
        }

        public bool ModificarSolucionAProblematica(solucionProblematica solucionProblematica1)
        {
            return SolucionAProblematicaDAO.modificarSolucionAProblematica(solucionProblematica1);
        }

        public List<problematicaAcademica> ObtenerProblematicasConSolucion()
        {
            return ProblematicaAcademicaDAO.obtenerProblematicasConSolucion();
        }

        public solucionProblematica ObtenerSolucionAProblematica(int idProblematica)
        {
            return SolucionAProblematicaDAO.obtenerSolucionAProblematica(idProblematica);
        }
    }
}
