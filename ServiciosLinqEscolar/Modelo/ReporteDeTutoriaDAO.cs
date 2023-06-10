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

        public static bool verificarRegistroPorReporteDeTutoria(int idTutoria)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            var reporteDeTutoria = (from reporteDeTutoriaQuery in conexionBD.reporteDeTutoria
                                    where reporteDeTutoriaQuery.idTutoria == idTutoria
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
    }
}