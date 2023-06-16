using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class AlumnoDAO
    {

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static List<alumno> obtenerAlumnosPorTutor(int idUsuario)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<alumno> alumnosBD = from alumnoQuery in conexionBD.alumno
                                           where alumnoQuery.idTutor == idUsuario
                                           select alumnoQuery;
            List<alumno> alumnosRecuperados = new List<alumno>();
            foreach (alumno alumno in alumnosBD)
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
                alumnosRecuperados.Add(alumno2);
            }


            return alumnosRecuperados;
        }

        public static List<alumno> obtenerAlumnos()
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<alumno> alumnosBD = from alumnoQuery in conexionBD.alumno
                                           where alumnoQuery.idTutor == null
                                           select alumnoQuery;
            List<alumno> alumnosRecuperados = new List<alumno>();
            foreach (alumno alumno in alumnosBD)
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
                alumnosRecuperados.Add(alumno2);
            }   
            return alumnosRecuperados;
        }

        public static bool asignarTutorAlumno(int idAlumno, int idTutor)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                alumno alumnoAsignar = (from alumno in conexionBD.alumno
                                        where alumno.idAlumno == idAlumno
                                        select alumno).FirstOrDefault();

                if (alumnoAsignar != null)
                {
                    alumnoAsignar.idTutor = idTutor;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}