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
    /// Lógica de interacción para ConsultarReportePorTutor.xaml
    /// </summary>
    public partial class ConsultarReportePorTutor : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();
        public ConsultarReportePorTutor()
        {
            InitializeComponent();
            TutoresViewModel modelo = new TutoresViewModel();
            cbTutoresAcademicos.ItemsSource = modelo.tutoresBD;
        }
        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        private void cbTutoresAcademicos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTutoresAcademicos.SelectedIndex != -1)
            {
                //obtener el objeto seleccionado en el cbTutoresAcademicos
                usuario tutorSeleccionado = (usuario)cbTutoresAcademicos.SelectedItem;
                obtenerReportes(tutorSeleccionado.idUsuario);
            }
        }

        private void obtenerReportes(int idTutor)
        {
            ReporteViewModel reporteViewModel = new ReporteViewModel(idTutor);
            dgReportes.ItemsSource = reporteViewModel.reportesBD;
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            if (dgReportes.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un reporte");
            }
            else
            {
                DetallesReporte detallesReporte = new DetallesReporte();
                detallesReporte.recibirVentanaAnterior(this);
                detallesReporte.recibirReporte((reporteDeTutoria)dgReportes.SelectedItem);
                detallesReporte.mostrarAlumnosAsistentes();
                detallesReporte.mostrarAlumnosNoAsistentes();
                detallesReporte.Show();
                this.IsEnabled = false;
            }
        }
    }
}
