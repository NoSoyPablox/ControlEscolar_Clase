﻿using System;
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
    }
}