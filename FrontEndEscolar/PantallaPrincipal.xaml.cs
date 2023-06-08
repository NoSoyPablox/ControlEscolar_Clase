using ServiceReferenceControlEscolar;
using System;
using System.Collections;
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
            //aqui desactivar todos los botones de la vista xaml
            btnLlenarReporte.Visibility = Visibility.Collapsed;
            btnConsultarReportePorTutor.Visibility = Visibility.Collapsed;
            btnRegistrarFechaSesion.Visibility = Visibility.Collapsed;
            btnAsignarTutorEstudiante.Visibility = Visibility.Collapsed;
            btnRegistrarSolucion.Visibility = Visibility.Collapsed;
            btnModificarSolucion.Visibility = Visibility.Collapsed;
            btnRegistrarTutor.Visibility = Visibility.Collapsed;
            btnRegistrarFechasCierre.Visibility = Visibility.Collapsed;
        }

        usuario usuarioSesion = null;

        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
            lbBienvenido.Content = "Bienvenido "+usuarioSesion.nombre;
        }

        public void mostrarOperaciones()
        {
            switch (usuarioSesion.rol)
            {
                case "Tutor":
                    btnLlenarReporte.Visibility = Visibility.Visible;
                    break;
                case "Coordinador de tutorias":
                    btnConsultarReportePorTutor.Visibility = Visibility.Visible;
                    btnRegistrarFechaSesion.Visibility = Visibility.Visible;
                    btnAsignarTutorEstudiante.Visibility = Visibility.Visible;
                    break;
                case "Jefe de carrera":
                    btnRegistrarSolucion.Visibility = Visibility.Visible;
                    btnModificarSolucion.Visibility = Visibility.Visible;
                    break;
                case "Administrador":
                    btnRegistrarTutor.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }   
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
