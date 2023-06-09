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
        public ObservableCollection<alumno> alumnosBD { get; set; } = new ObservableCollection<alumno>();

        public AlumnoViewModel(int idTutor)
        {
            alumnosBD = new ObservableCollection<alumno>();
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
                    alumnosBD.Add(usuarioObtenido);
                }
            }
        }
    }
}
