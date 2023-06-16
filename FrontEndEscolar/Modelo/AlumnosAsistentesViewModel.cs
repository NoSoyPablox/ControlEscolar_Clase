using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{

    internal class AlumnosAsistentesViewModel
    {
        public ObservableCollection<alumno> alumnosAsistentesBD { get; set; } = new ObservableCollection<alumno>();

        public AlumnosAsistentesViewModel(int idReporte)
        {
            alumnosAsistentesBD = new ObservableCollection<alumno>();
            solicitarInformacionServicio(idReporte);
        }

        private async void solicitarInformacionServicio(int idReporte)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                alumno[] alumnoService = await conexionServicios.ObtenerAsistentesPorReporteAsync(idReporte);
                foreach (alumno alumnoObtenido in alumnoService)
                {
                    alumnosAsistentesBD.Add(alumnoObtenido);
                }
            }
        }

    }
}
