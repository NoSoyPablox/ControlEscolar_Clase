using System;
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

        public static Boolean modificarSolucionAProblematica(solucionProblematica solucionProblematicaRecibida)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var solucionProblematica = (from solucionProblematica1 in conexionBD.solucionProblematica
                                            where solucionProblematica1.idSolucion == solucionProblematicaRecibida.idSolucion
                                            select solucionProblematica1).FirstOrDefault();
                solucionProblematica.descripcion = solucionProblematicaRecibida.descripcion;
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static solucionProblematica obtenerSolucionAProblematica(int idProblematicaRecibida)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var solucionProblematica = (from solucionProblematica1 in conexionBD.solucionProblematica
                                            where solucionProblematica1.idProblematica == idProblematicaRecibida
                                            select solucionProblematica1).FirstOrDefault();

                var solucionRecuperada = new solucionProblematica()
                {
                    idSolucion = solucionProblematica.idSolucion,
                    descripcion = solucionProblematica.descripcion,
                    fechaRegistro = solucionProblematica.fechaRegistro,
                    idProblematica = solucionProblematica.idProblematica
                };

                return solucionRecuperada;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}