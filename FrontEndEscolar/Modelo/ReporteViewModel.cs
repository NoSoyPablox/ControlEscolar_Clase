using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class ReporteViewModel
    {
        public ObservableCollection<reporteDeTutoria> reportesBD { get; set; } = new ObservableCollection<reporteDeTutoria>();

        public ReporteViewModel(int idTutor)
        {
        reportesBD = new ObservableCollection<reporteDeTutoria>();
        solicitarInformacionServicio(idTutor);
        }

        private async void solicitarInformacionServicio(int idTutor)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                reporteDeTutoria[] reporteService = await conexionServicios.ObtenerReportesPorTutorAsync(idTutor);
                foreach (reporteDeTutoria reporteObtenido in reporteService)
                {
                    reportesBD.Add(reporteObtenido);
                }
            }
        }

    }


}
