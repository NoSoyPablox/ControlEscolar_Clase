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

        public static bool registrarListaAsistenciaAReporte(int idReporteRecibido, alumno[] alumnosAsistenciaRecibidos)
        {
            try
            {
                for (int i = 0; i < alumnosAsistenciaRecibidos.Length; i++)
                {
                    DataClassesEscolarUVDataContext conexionBD = getConnection();
                    var listaAsistencia = new listaAsistencia()
                    {
                        idReporteTutoria = idReporteRecibido,
                        idEstudiante = alumnosAsistenciaRecibidos[i].idAlumno,
                        asistencia = true
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