using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class PeriodoEscolarViewModel
    {
        public ObservableCollection<periodoEscolar> periodosEscolaresBD { get; set; } = new ObservableCollection<periodoEscolar>();

        public PeriodoEscolarViewModel()
        {
            periodosEscolaresBD = new ObservableCollection<periodoEscolar>();
            solicitarInformacionServicio();
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                periodoEscolar[] periodoEscolarService = await conexionServicios.ObtenerPeriodosEscolaresAsync();
                foreach (periodoEscolar periodoEscolarObtenido in periodoEscolarService)
                {
                    periodosEscolaresBD.Add(periodoEscolarObtenido);
                }
            }
        }   

    }
}
