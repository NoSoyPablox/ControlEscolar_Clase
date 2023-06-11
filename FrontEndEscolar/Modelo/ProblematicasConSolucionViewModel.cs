using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class ProblematicasConSolucionViewModel
    {
        public ObservableCollection<problematicaAcademica> problematicasConSolucion { get; set; } = new ObservableCollection<problematicaAcademica>();

        public ProblematicasConSolucionViewModel()
        {
            problematicasConSolucion = new ObservableCollection<problematicaAcademica>();
            solicitarInformacionServicio();
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                problematicaAcademica[] problematicasService = await conexionServicios.ObtenerProblematicasConSolucionAsync();
                foreach (problematicaAcademica problematicaObtenida in problematicasService)
                {
                    problematicasConSolucion.Add(problematicaObtenida);
                }
            }
        }
    }
}
