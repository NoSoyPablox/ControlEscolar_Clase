using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class ReporteDeTutoriaDAO
    {
        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static bool verificarRegistroPorReporteDeTutoria(int idTutoria, int idTutor)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            var reporteDeTutoria = (from reporteDeTutoriaQuery in conexionBD.reporteDeTutoria
                                    where reporteDeTutoriaQuery.idTutoria == idTutoria && reporteDeTutoriaQuery.idTutor == idTutor
                                    select reporteDeTutoriaQuery).FirstOrDefault();
            if (reporteDeTutoria != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool registrarReporteTutoria(string comentariosGeneralesRecibidos, int numeroSesionRecibido, int idTutorRecibido, int idTutoriaRecibido)
        {
            try
            {
                var reporteDeTutoria1 = new reporteDeTutoria()
                {
                    fecha = DateTime.Now,
                    comentariosGenerales = comentariosGeneralesRecibidos,
                    numeroSesion = numeroSesionRecibido,
                    idTutor = idTutorRecibido,
                    idTutoria = idTutoriaRecibido
                };
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                conexionBD.reporteDeTutoria.InsertOnSubmit(reporteDeTutoria1);
                conexionBD.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static reporteDeTutoria obtenerReporteCreado(int idTutoriaRecibido, int idTutorRecibido)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var reporteDeTutoria = (from reporteDeTutoriaQuery in conexionBD.reporteDeTutoria
                                        where reporteDeTutoriaQuery.idTutoria == idTutoriaRecibido && reporteDeTutoriaQuery.idTutor == idTutorRecibido
                                        select reporteDeTutoriaQuery).FirstOrDefault();
                var reporteDeTutoria2 = new reporteDeTutoria()
                {
                    idReporte = reporteDeTutoria.idReporte,
                    fecha = reporteDeTutoria.fecha,
                    comentariosGenerales = reporteDeTutoria.comentariosGenerales,
                    numeroSesion = reporteDeTutoria.numeroSesion,
                    idTutor = reporteDeTutoria.idTutor,
                    idTutoria = reporteDeTutoria.idTutoria
                };
                return reporteDeTutoria2;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public static List<reporteDeTutoria> obtenerReportesPorTutor(int idTutor)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var reportesDeTutoria = (from reporteDeTutoriaQuery in conexionBD.reporteDeTutoria
                                         where reporteDeTutoriaQuery.idTutor == idTutor
                                         select reporteDeTutoriaQuery);
                List<reporteDeTutoria> reportesDeTutoria2 = new List<reporteDeTutoria>();
                foreach (reporteDeTutoria reporte in reportesDeTutoria)
                {
                    var reporteDeTutoria3 = new reporteDeTutoria()
                    {
                        idReporte = reporte.idReporte,
                        fecha = reporte.fecha,
                        comentariosGenerales = reporte.comentariosGenerales,
                        numeroSesion = reporte.numeroSesion,
                        idTutor = reporte.idTutor,
                        idTutoria = reporte.idTutoria
                    };
                    reportesDeTutoria2.Add(reporteDeTutoria3);
                }
                return reportesDeTutoria2;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}