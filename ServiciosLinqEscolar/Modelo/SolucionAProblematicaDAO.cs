﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class SolucionAProblematicaDAO
    {
        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static Boolean registrarSolucionAProblematica(solucionProblematica solucionProblematicaRecibida, int idProblematicaRecibida)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var solucionProblematica = new solucionProblematica()
                {
                    descripcion = solucionProblematicaRecibida.descripcion,
                    fechaRegistro = DateTime.Now,
                    idProblematica = idProblematicaRecibida
                };
                conexionBD.solucionProblematica.InsertOnSubmit(solucionProblematica);
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