using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class PeriodoEscolarDAO
    {

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }

        public static List<periodoEscolar> obtenerPeriodosEscolares()
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<periodoEscolar> periodosEscolaresBD = from periodoEscolarQuery in conexionBD.periodoEscolar
                                                             select periodoEscolarQuery;
            List<periodoEscolar> periodosEscolaresRecuperados = new List<periodoEscolar>();
            foreach (periodoEscolar periodoEscolar in periodosEscolaresBD)
            {
                var periodoEscolar2 = new periodoEscolar()
                {
                    idPeriodo = periodoEscolar.idPeriodo,
                    nombre = periodoEscolar.nombre,
                    fechaInicio = periodoEscolar.fechaInicio,
                    fechaFin = periodoEscolar.fechaFin
                };
                periodosEscolaresRecuperados.Add(periodoEscolar2);
            }
            return periodosEscolaresRecuperados;
        }
    }
}