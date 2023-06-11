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
    }
}