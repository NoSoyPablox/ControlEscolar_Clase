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

        public static bool registrarFechasSesionTutoria(string fechaSesion1, string fechaSesion2, string fechaSesion3, int idPeriodo)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                //Aqui antes ver si ya existe un registro en la base de datos con el mismo idPeriodoEscolar
                var tutoria = (from tutoriaQuery in conexionBD.tutoria
                               where tutoriaQuery.idPeriodoEscolar == idPeriodo
                               select tutoriaQuery).FirstOrDefault();
                if (tutoria != null)
                {
                    return false;
                }
                else
                {
                    var tutoria1 = new tutoria()
                    {
                        fechaTutoria = DateTime.Parse(fechaSesion1),
                        idPeriodoEscolar = idPeriodo,
                        numeroSesion = 1
                    };
                    var tutoria2 = new tutoria()
                    {
                        fechaTutoria = DateTime.Parse(fechaSesion2),
                        idPeriodoEscolar = idPeriodo,
                        numeroSesion = 2
                    };
                    var tutoria3 = new tutoria()
                    {
                        fechaTutoria = DateTime.Parse(fechaSesion3),
                        idPeriodoEscolar = idPeriodo,
                        numeroSesion = 3
                    };

                    conexionBD.tutoria.InsertOnSubmit(tutoria1);
                    conexionBD.tutoria.InsertOnSubmit(tutoria2);
                    conexionBD.tutoria.InsertOnSubmit(tutoria3);
                    conexionBD.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<tutoria> obtenerTutoriasPorPeriodoEscolar(int idPeriodo)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                IQueryable<tutoria> tutorias = from tutoriaQuery in conexionBD.tutoria
                                               where tutoriaQuery.idPeriodoEscolar == idPeriodo
                                               select tutoriaQuery;
                List<tutoria> tutoriasObtenidas = new List<tutoria>();
                foreach (tutoria tutoriaObtenida in tutorias)
                {
                    var tutoria1= new tutoria()
                    {
                        idTutoria = tutoriaObtenida.idTutoria,
                        fechaTutoria = tutoriaObtenida.fechaTutoria,
                        idPeriodoEscolar = tutoriaObtenida.idPeriodoEscolar,
                        numeroSesion = tutoriaObtenida.numeroSesion
                    };
                    tutoriasObtenidas.Add(tutoria1);
                }
                return tutoriasObtenidas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool registrarFechaCierreATutoriasPeriodoEscolar(int idTutoria1, string fechaInicio1, string fechaCierre1, int idTutoria2, string fechaInicio2, string fechaCierre2, int idTutoria3, string fechaInicio3, string fechaCierre3)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            try
            {
                var fechaCierreObtenida = (from tutoriaQuery in conexionBD.fechaCierreReporte
                                    where tutoriaQuery.idTutoria == idTutoria1
                                    select tutoriaQuery).FirstOrDefault();
                if (fechaCierreObtenida != null)
                {
                    return false;
                }
                else
                {
                    var fechaCierre1BD = new fechaCierreReporte()
                    {
                        fechaInicio = DateTime.Parse(fechaInicio1),
                        fechaLimite = DateTime.Parse(fechaCierre1),
                        idTutoria = idTutoria1
                    };
                    var fechaCierre2BD = new fechaCierreReporte()
                    {
                        fechaInicio = DateTime.Parse(fechaInicio2),
                        fechaLimite = DateTime.Parse(fechaCierre2),
                        idTutoria = idTutoria2
                    };
                    var fechaCierre3BD = new fechaCierreReporte()
                    {
                        fechaInicio = DateTime.Parse(fechaInicio3),
                        fechaLimite = DateTime.Parse(fechaCierre3),
                        idTutoria = idTutoria3
                    };
                    conexionBD.fechaCierreReporte.InsertOnSubmit(fechaCierre1BD);
                    conexionBD.fechaCierreReporte.InsertOnSubmit(fechaCierre2BD);
                    conexionBD.fechaCierreReporte.InsertOnSubmit(fechaCierre3BD);
                    conexionBD.SubmitChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public static bool verificarFechaCierreVigente(int idTutoria)
        {
              DataClassesEscolarUVDataContext conexionBD = getConnection();
            try
            {
                var fechaCierreObtenida = (from tutoriaQuery in conexionBD.fechaCierreReporte
                                           where tutoriaQuery.idTutoria == idTutoria
                                           select tutoriaQuery).FirstOrDefault();
                if (fechaCierreObtenida != null)
                {
                    DateTime fechaActual = DateTime.Now;
                    if (fechaActual >= fechaCierreObtenida.fechaInicio && fechaActual <= fechaCierreObtenida.fechaLimite)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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