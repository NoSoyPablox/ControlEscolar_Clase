using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class TutoriaDAO
    {
        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static bool registrarFechasSesionTutoria(string fechaSesion1, string fechaSesion2, string fechaSesion3, int idPeriodoEscolar)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var tutoria1 = new tutoria()
                {
                    fechaTutoria = DateTime.Parse(fechaSesion1),
                    //idPeriodo = idPeriodoEscolar,
                    numeroSesion = 1
                };
                var tutoria2 = new tutoria()
                {
                    fechaTutoria = DateTime.Parse(fechaSesion2),
                    //idPeriodo = idPeriodoEscolar,
                    numeroSesion = 2
                };
                var tutoria3 = new tutoria()
                {
                    fechaTutoria = DateTime.Parse(fechaSesion3),
                    //idPeriodo = idPeriodoEscolar,
                    numeroSesion = 3
                };

                conexionBD.tutoria.InsertOnSubmit(tutoria1);
                conexionBD.tutoria.InsertOnSubmit(tutoria2);
                conexionBD.tutoria.InsertOnSubmit(tutoria3);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}