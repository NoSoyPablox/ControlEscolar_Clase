using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class ListaAsistenciaDAO
    {
        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static bool registrarListaAsistenciaAReporte(int idReporteRecibido, List<int> idAsistentes, List<int> idNoAsistentes)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                foreach (var alumno1 in idAsistentes)
                {
                    var listaAsistencia = new listaAsistencia()
                    {
                        idReporteTutoria = idReporteRecibido,
                        idEstudiante = alumno1,
                        asistencia = true
                    };
                    conexionBD.listaAsistencia.InsertOnSubmit(listaAsistencia);
                    conexionBD.SubmitChanges();
                }
                foreach (var alumno2 in idNoAsistentes)
                {
                    var listaAsistencia = new listaAsistencia()
                    {
                        idReporteTutoria = idReporteRecibido,
                        idEstudiante = alumno2,
                        asistencia = false
                    };
                    conexionBD.listaAsistencia.InsertOnSubmit(listaAsistencia);
                    conexionBD.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<alumno> obtenerAsistentesPorReporte(int idReporte)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var asistentes = (from listaAsistencia in conexionBD.listaAsistencia
                                  join alumno in conexionBD.alumno on listaAsistencia.idEstudiante equals alumno.idAlumno
                                  where listaAsistencia.idReporteTutoria == idReporte && listaAsistencia.asistencia == true
                                  select alumno).ToList();
                List<alumno> alumnosAsistentes = new List<alumno>();
                foreach (var alumno in asistentes)
                {
                    var alumno2 = new alumno()
                    {
                        idAlumno = alumno.idAlumno,
                        nombre = alumno.nombre,
                        apellidoPaterno = alumno.apellidoPaterno,
                        apellidoMaterno = alumno.apellidoMaterno,
                        matricula = alumno.matricula,
                        idTutor = alumno.idTutor
                    };
                    alumnosAsistentes.Add(alumno2);
                }
                return alumnosAsistentes;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public static List<alumno> obtenerNoAsistentesPorReporte(int idReporte)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var asistentes = (from listaAsistencia in conexionBD.listaAsistencia
                                  join alumno in conexionBD.alumno on listaAsistencia.idEstudiante equals alumno.idAlumno
                                  where listaAsistencia.idReporteTutoria == idReporte && listaAsistencia.asistencia == false
                                  select alumno).ToList();
                List<alumno> alumnosNoAsistentes= new List<alumno>();
                foreach (var alumno in asistentes)
                {
                    var alumno2 = new alumno()
                    {
                        idAlumno = alumno.idAlumno,
                        nombre = alumno.nombre,
                        apellidoPaterno = alumno.apellidoPaterno,
                        apellidoMaterno = alumno.apellidoMaterno,
                        matricula = alumno.matricula,
                        idTutor = alumno.idTutor
                    };
                    alumnosNoAsistentes.Add(alumno2);
                }
                return alumnosNoAsistentes;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}