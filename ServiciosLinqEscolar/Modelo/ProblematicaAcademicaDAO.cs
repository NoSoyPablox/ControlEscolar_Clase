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
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
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

        public static List<problematicaAcademica> obtenerProblematicasSinSolucion()
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                //quiero recuperar las problematicas academicas cuyos idProblematica no aparezca como llave foranea en la tabla solucionProblematica
                var problematicas = (from p in conexionBD.problematicaAcademica
                                     where !(from s in conexionBD.solucionProblematica
                                     select s.idProblematica).Contains(p.idProblematica)
                                     select p);
                List<problematicaAcademica> problematicasSinSolucion = new List<problematicaAcademica>();
                foreach (problematicaAcademica problematica in problematicas)
                {
                    var problematicaSinSolucion2 = new problematicaAcademica()
                    {
                        idProblematica = problematica.idProblematica,
                        numAlumnos = problematica.numAlumnos,
                        titulo = problematica.titulo,
                        descripcion = problematica.descripcion,
                        fechaRegistro = problematica.fechaRegistro,
                        categoria = problematica.categoria,
                        idReporteTutoria = problematica.idReporteTutoria
                    };
                    problematicasSinSolucion.Add(problematicaSinSolucion2);
                }
                return problematicasSinSolucion;
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}