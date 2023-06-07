using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontEndEscolar
{
    /// <summary>
    /// Lógica de interacción para PantallaPrincipal.xaml
    /// </summary>
    public partial class PantallaPrincipal : Window
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        usuario usuarioSesion = null;

        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
            lbBienvenido.Content = "Bienvenido "+usuarioSesion.nombre;
        }

        public void mostrarOperaciones()
        {
            //hacer un switch
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            InicioSesion inicioSesion = new InicioSesion();
            inicioSesion.Show();
            this.Close();
        }

        private void btnRegistrarTutor_Click(object sender, RoutedEventArgs e)
        {
            RegistrarTutorAcademico registrarTutorAcademico = new RegistrarTutorAcademico();
            registrarTutorAcademico.recibirVentanaAnterior(this);
            this.IsEnabled = false;
            registrarTutorAcademico.Show();

        }
    }
}
