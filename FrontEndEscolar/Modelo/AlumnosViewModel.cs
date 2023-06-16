using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class AlumnosViewModel
    {
        public ObservableCollection<alumno> alumnosBD { get; set; } = new ObservableCollection<alumno>();

        public AlumnosViewModel()
        {
            alumnosBD = new ObservableCollection<alumno>();
            solicitarInformacionServicio();
        }
        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                alumno[] usuarioService = await conexionServicios.obtenerAlumnosAsync();
                foreach (alumno usuarioObtenido in usuarioService)
                {
                    alumnosBD.Add(usuarioObtenido);
                }
            }
        }
    }
}
