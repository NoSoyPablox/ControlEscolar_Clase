using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class AlumnosNoAsistentesViewModel
    {
        public ObservableCollection<alumno> alumnosNoAsistentesBD { get; set; } = new ObservableCollection<alumno>();

        public AlumnosNoAsistentesViewModel(int idReporte)
        {
            alumnosNoAsistentesBD = new ObservableCollection<alumno>();
            solicitarInformacionServicio(idReporte);
        }

        private async void solicitarInformacionServicio(int idReporte)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                alumno[] alumnoService = await conexionServicios.ObtenerNoAsistentesPorReporteAsync(idReporte);
                foreach (alumno alumnoObtenido in alumnoService)
                {
                    alumnosNoAsistentesBD.Add(alumnoObtenido);
                }
            }
        }
    }
}
