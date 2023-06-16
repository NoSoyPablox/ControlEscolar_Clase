using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class ProblematicasSinSolucionViewModel
    {
        public ObservableCollection<problematicaAcademica> problematicasSinSolucion { get; set; } = new ObservableCollection<problematicaAcademica>();

        public ProblematicasSinSolucionViewModel()
        {
            problematicasSinSolucion = new ObservableCollection<problematicaAcademica>();
            solicitarInformacionServicio();
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                problematicaAcademica[] problematicasService = await conexionServicios.ObtenerProblematicasSinSolucionAsync();
                foreach (problematicaAcademica problematicaObtenida in problematicasService)
                {
                    problematicasSinSolucion.Add(problematicaObtenida);
                }
            }
        }
    }
}
