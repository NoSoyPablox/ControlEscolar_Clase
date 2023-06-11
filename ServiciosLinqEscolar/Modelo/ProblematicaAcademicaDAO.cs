using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class ProblematicaAcademicaDAO
    {
        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        //Metodo que registra las problematicas recibidas en una lista de problematicas en la base de datos
        public static bool registrarProblematicasAcademicas(List<problematicaAcademica> problematicasRecibidas, int idReporteRecibido)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            try
            {
                foreach (problematicaAcademica problematica in problematicasRecibidas)
                {
                    var problematica2 = new problematicaAcademica()
                    {
                        numAlumnos = problematica.numAlumnos,
                        titulo = problematica.titulo,
                        descripcion = problematica.descripcion,
                        fechaRegistro = DateTime.Now,
                        categoria = problematica.categoria,
                        idReporteTutoria = idReporteRecibido
                    };
                    conexionBD.problematicaAcademica.InsertOnSubmit(problematica2);
                }
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}