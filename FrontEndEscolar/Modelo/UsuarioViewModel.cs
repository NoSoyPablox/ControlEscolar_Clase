using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndEscolar.Modelo
{

    internal class UsuarioViewModel
    {
        public ObservableCollection<usuario> usuariosBD { get; set; } = new ObservableCollection<usuario>();
        
        public UsuarioViewModel() 
        {
            usuariosBD = new ObservableCollection<usuario>();
            solicitarInformacionServicio();
        }
        private async void solicitarInformacionServicio()
        {
            var conexionServicios = new Service1Client();
            if(conexionServicios != null)
            {
                usuario[] usuarioService = await conexionServicios.ObtenerUsuariosAsync();
                foreach (usuario usuarioObtenido in usuarioService)
                {
                    usuariosBD.Add(usuarioObtenido);
                }
            }
        }


    }

}
