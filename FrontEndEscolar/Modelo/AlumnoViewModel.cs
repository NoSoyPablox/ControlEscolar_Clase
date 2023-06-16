using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class AlumnoViewModel
    {
        public ObservableCollection<AlumnoLocal> alumnosBD { get; set; } = new ObservableCollection<AlumnoLocal>();

        public AlumnoViewModel(int idTutor)
        {
            alumnosBD = new ObservableCollection<AlumnoLocal>();
            solicitarInformacionServicio(idTutor);
        }

        private async void solicitarInformacionServicio(int idTutor)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                alumno[] usuarioService = await conexionServicios.ObtenerEstudiantesPorTutorAsync(idTutor);
                foreach (alumno usuarioObtenido in usuarioService)
                {
                    var alumnoALocal = new AlumnoLocal()
                    {
                        idAlumno = usuarioObtenido.idAlumno,
                        nombre = usuarioObtenido.nombre,
                        apellidoPaterno = usuarioObtenido.apellidoPaterno,
                        apellidoMaterno = usuarioObtenido.apellidoMaterno,
                        matricula = usuarioObtenido.matricula,
                    };
                    alumnosBD.Add(alumnoALocal);
                }
            }
        }
    }
}
