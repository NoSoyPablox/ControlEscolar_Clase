using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class AlumnoDAO
    {
        /*public static List<alumno> obtenerAlumnosPorTutor(int idUsuario)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<alumno> alumnosBD = from alumnoQuery in conexionBD.alumno
                                           where alumnoQuery.idTutor == idUsuario
                                           select alumnoQuery;

            return alumnosBD.ToList();
        }

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }*/
    }
}