using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class TutoresViewModel
    {
        public ObservableCollection<usuario> tutoresBD { get; set; } = new ObservableCollection<usuario>();

        public TutoresViewModel()
        {
            tutoresBD = new ObservableCollection<usuario>();
            solicitarInformacionServicio();
        }

        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                usuario[] usuarioService = await conexionServicios.ObtenerTutoresAsync();
                foreach (usuario usuarioObtenido in usuarioService)
                {
                    tutoresBD.Add(usuarioObtenido);
                }
            }
        }

    }
}
