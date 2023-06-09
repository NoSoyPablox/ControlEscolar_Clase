using FrontEndEscolar.Modelo;
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
    /// Lógica de interacción para LlenarReporteTutoria.xaml
    /// </summary>
    public partial class LlenarReporteTutoria : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();

        public LlenarReporteTutoria()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        usuario usuarioSesion = new usuario();
        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
        }

        public void obtenerAlumnos(int idUsuario)
        {
            AlumnoViewModel modelo = new AlumnoViewModel(usuarioSesion.idUsuario);
            dgEstudiantes.ItemsSource = modelo.alumnosBD;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregarProblematica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }
    }
}
