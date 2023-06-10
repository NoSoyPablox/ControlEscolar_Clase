using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{
    internal class TutoriasViewModel
    {
        public ObservableCollection<tutoria> tutoriasBD { get; set; } = new ObservableCollection<tutoria>();

        public TutoriasViewModel(int idTutoriaRecibida)
        {
            tutoriasBD = new ObservableCollection<tutoria>();
            solicitarInformacionServicio(idTutoriaRecibida);
        }

        private async void solicitarInformacionServicio(int idTutoria)
        {
            var conexionServicios = new Service1Client();
            if (conexionServicios != null)
            {
                tutoria[] usuarioService = await conexionServicios.ObtenerTutoriasPorPeriodoEscolarAsync(idTutoria);
                foreach (tutoria usuarioObtenido in usuarioService)
                {
                    tutoriasBD.Add(usuarioObtenido);
                }
            }
        }
    }
}
