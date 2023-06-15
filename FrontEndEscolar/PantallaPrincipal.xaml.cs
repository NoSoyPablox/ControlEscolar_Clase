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
            btnLlenarReporte.Visibility = Visibility.Collapsed;
            btnConsultarReportePorTutor.Visibility = Visibility.Collapsed;
            btnRegistrarFechaSesion.Visibility = Visibility.Collapsed;
            btnAsignarTutorEstudiante.Visibility = Visibility.Collapsed;
            btnRegistrarSolucion.Visibility = Visibility.Collapsed;
            btnModificarSolucion.Visibility = Visibility.Collapsed;
            btnRegistrarTutor.Visibility = Visibility.Collapsed;
            btnRegistrarFechasCierre.Visibility = Visibility.Collapsed;
        }

        usuario usuarioSesion = new usuario();

        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
            lbBienvenido.Content = "Bienvenido "+usuarioSesion.nombre;
        }

        public void mostrarOperaciones()
        {
            switch (usuarioSesion.rol)
            {
                case "Tutor academico":
                    btnLlenarReporte.Visibility = Visibility.Visible;
                    break;
                case "Coordinador de tutorias":
                    btnConsultarReportePorTutor.Visibility = Visibility.Visible;
                    btnRegistrarFechaSesion.Visibility = Visibility.Visible;
                    btnAsignarTutorEstudiante.Visibility = Visibility.Visible;
                    btnRegistrarFechasCierre.Visibility = Visibility.Visible;
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

        private void btnRegistrarFechaSesion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarFechasSesion registrarFechasSesion = new RegistrarFechasSesion();
            registrarFechasSesion.recibirVentanaAnterior(this);
            registrarFechasSesion.cargarPeriodosEscolares();
            this.IsEnabled = false;
            registrarFechasSesion.Show();

        }

        private void btnLlenarReporte_Click(object sender, RoutedEventArgs e)
        {
            LlenarReporteTutoria llenarReporteTutoria = new LlenarReporteTutoria();
            llenarReporteTutoria.recibirUsuarioSesion(usuarioSesion);
            llenarReporteTutoria.obtenerAlumnos(usuarioSesion.idUsuario);
            llenarReporteTutoria.recibirVentanaAnterior(this);
            this.IsEnabled = false;
            llenarReporteTutoria.Show();
        }

        private void btnAsignarTutorEstudiante_Click(object sender, RoutedEventArgs e)
        {
            AsignarTutorAEstudiante asignarTutorAEstudiante = new AsignarTutorAEstudiante();
            asignarTutorAEstudiante.recibirVentanaAnterior(this);
            this.IsEnabled = false;
            asignarTutorAEstudiante.Show();
        }

        private void btnRegistrarFechasCierre_Click(object sender, RoutedEventArgs e)
        {
            RegistrarFechaCierre registrarFechaCierre = new RegistrarFechaCierre();
            registrarFechaCierre.recibirVentanaAnterior(this);
            registrarFechaCierre.mostrarPeriodos();
            this.IsEnabled = false;
            registrarFechaCierre.Show();
        }

        private void btnConsultarReportePorTutor_Click(object sender, RoutedEventArgs e)
        {
            ConsultarReportePorTutor consultarReportePorTutor = new ConsultarReportePorTutor();
            consultarReportePorTutor.recibirVentanaAnterior(this);
            this.IsEnabled = false;
            consultarReportePorTutor.Show();
        }

        private void btnRegistrarSolucion_Click(object sender, RoutedEventArgs e)
        {
            RegistrarSolucionAProblematica registrarSolucionAProblematica = new RegistrarSolucionAProblematica();
            registrarSolucionAProblematica.recibirVentanaAnterior(this);
            registrarSolucionAProblematica.mostrarProblematicasSinSolucion();
            this.IsEnabled = false;
            registrarSolucionAProblematica.Show();
        }

        private void btnModificarSolucion_Click(object sender, RoutedEventArgs e)
        {
            ModificarSolucionAProblematica modificarSolucionAProblematica = new ModificarSolucionAProblematica();
            modificarSolucionAProblematica.recibirVentanaAnterior(this);
            modificarSolucionAProblematica.mostrarProblematicasConSolucion();
            this.IsEnabled = false;
            modificarSolucionAProblematica.Show();
        }
    }
}
