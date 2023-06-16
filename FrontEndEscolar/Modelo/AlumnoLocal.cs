using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FrontEndEscolar.Modelo
{
    internal class AlumnoLocal
    {
        public int idAlumno { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string matricula { get; set; }
        public int idTutor { get; set; }
        public bool isSelected { get; set; }

    }
}
