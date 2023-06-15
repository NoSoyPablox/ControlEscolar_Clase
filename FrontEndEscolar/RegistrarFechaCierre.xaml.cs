using FrontEndEscolar.Modelo;
using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Lógica de interacción para RegistrarFechaCierre.xaml
    /// </summary>
    public partial class RegistrarFechaCierre : Window
    { 

        tutoria tutoria1Periodo = new tutoria();
        tutoria tutoria2Periodo = new tutoria();
        tutoria tutoria3Periodo = new tutoria();
        bool existenRegistros = true;

        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();
        public RegistrarFechaCierre()
        {
            InitializeComponent();
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

        public void mostrarPeriodos()
        {
            PeriodoEscolarViewModel modelo = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = modelo.periodosEscolaresBD;
        }

        private void cbPeriodoEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbPeriodoEscolar.SelectedIndex != -1)
            {
                periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
                DateTime fechaInicio = (DateTime)periodoSeleccionado.fechaInicio;
                DateTime fechaFin = (DateTime)periodoSeleccionado.fechaFin;
                lbFechaInicioPeriodo.Content = fechaInicio.ToString("dd-MM-yyyy");
                lbFechaFinPeriodo.Content = fechaFin.ToString("dd-MM-yyyy");

                int idPeriodo = periodoSeleccionado.idPeriodo;
                mostrarFechasDelPeriodo(idPeriodo);
            }
        }

        private async void mostrarFechasDelPeriodo(int idPeriodo)
        {
            tutoria[] tutoriasRecuperadas = null;
            Service1Client servicio = new Service1Client();
            periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;

            tutoriasRecuperadas = await servicio.ObtenerTutoriasPorPeriodoEscolarAsync(idPeriodo);
            if (tutoriasRecuperadas.Length == 0)
            {
                MessageBox.Show("No se encontraron tutorias para el periodo seleccionado");
                lbTutoria1.Content = "No registrado";
                lbTutoria2.Content = "No registrado";
                lbTutoria3.Content = "No registrado";
                existenRegistros = false;
                return;
            }
            lbTutoria1.Content = tutoriasRecuperadas[0].fechaTutoria.ToString().Substring(0, 10);
            lbTutoria2.Content = tutoriasRecuperadas[1].fechaTutoria.ToString().Substring(0, 10);
            lbTutoria3.Content = tutoriasRecuperadas[2].fechaTutoria.ToString().Substring(0, 10);
            tutoria1Periodo = tutoriasRecuperadas[0];
            tutoria2Periodo = tutoriasRecuperadas[1];
            tutoria3Periodo = tutoriasRecuperadas[2];
        }


        private void comprobarFechas()
        {
            DateTime fechaLimite1 = dpFechaLimite1.SelectedDate.Value;
            DateTime fechaLimite2 = dpFechaLimite2.SelectedDate.Value;
            DateTime fechaLimite3 = dpFechaLimite3.SelectedDate.Value;
            periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;

            if (fechaLimite1 > tutoria2Periodo.fechaTutoria)
            {
                MessageBox.Show("El limite de entrega del primer reporte de tutoria no puede ser posterior a la fecha de sesion de la segunda tutoria");

            }else if (fechaLimite1 < tutoria1Periodo.fechaTutoria)
            {
                MessageBox.Show("El limite de entrega del primer reporte de tutoria no puede ser anterior a la fecha de sesion de la primera tutoria");
            }else if (fechaLimite2 > tutoria3Periodo.fechaTutoria)
            {
                MessageBox.Show("El limite de entrega del primer reporte de tutoria no puede ser posterior a la fecha de sesion de la tercera tutoria");
            }else if (fechaLimite2 < tutoria2Periodo.fechaTutoria)
            {
                MessageBox.Show("El limite de entrega del segundo reporte de tutoria no puede ser anterior a la fecha de sesion de la segunda tutoria");
            }else if (fechaLimite3 > periodoSeleccionado.fechaFin)
            {
                MessageBox.Show("El limite de entrega del tercer reporte de tutoria no puede ser posterior a la fecha de fin del periodo escolar");
            }else if (fechaLimite3 < tutoria3Periodo.fechaTutoria)
            {
                MessageBox.Show("El limite de entrega del tercer reporte de tutoria no puede ser anterior a la fecha de sesion de la tercera tutoria");
            }
            else
            {
                string fechaInicio1 = tutoria1Periodo.fechaTutoria.ToString();
                string fechaInicio2 = tutoria2Periodo.fechaTutoria.ToString();
                string fechaInicio3 = tutoria3Periodo.fechaTutoria.ToString();
                registrarFechasCierre(tutoria1Periodo.idTutoria, fechaInicio1, fechaLimite1.ToString(), tutoria2Periodo.idTutoria, fechaInicio2, fechaLimite2.ToString(), tutoria3Periodo.idTutoria, fechaInicio3, fechaLimite3.ToString());
                
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (cbPeriodoEscolar.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un periodo escolar");
            }
            else if (existenRegistros == false)
            {
                MessageBox.Show("No puede registrar estas fechas ya que el periodo escolar no tiene registros de tutoria");
            }
            else if (dpFechaLimite1.SelectedDate == null || dpFechaLimite2.SelectedDate == null || dpFechaLimite3.SelectedDate == null)
            {
                MessageBox.Show("Seleccione las fechas limite de entrega de los reportes de tutoria");
            }
            else
            {
                comprobarFechas();
            }

        }

        private async void registrarFechasCierre(int idTutoria1, string fechaInicio1, string fechaCierre1, int idTutoria2, string fechaInicio2, string fechaCierre2, int idTutoria3, string fechaInicio3, string fechaCierre3)
        {
            Service1Client servicio = new Service1Client();
            using (var conexionServicios = new Service1Client())
            {
                bool resultado = await conexionServicios.RegistrarFechaCierreATutoriasPeriodoEscolarAsync(idTutoria1, fechaInicio1, fechaCierre1, idTutoria2, fechaInicio2, fechaCierre2, idTutoria3, fechaInicio3, fechaCierre3);
                if (resultado == true)
                {
                    MessageBox.Show("Fechas de cierre registradas correctamente");
                    cbPeriodoEscolar.SelectedIndex = -1;
                    dpFechaLimite1.SelectedDate = null;
                    dpFechaLimite2.SelectedDate = null;
                    dpFechaLimite3.SelectedDate = null;
                    lbFechaInicioPeriodo.Content = "";
                    lbFechaFinPeriodo.Content = "";
                }
                else
                {
                    MessageBox.Show("Ya existen fechas de cierre registradas para estas tutorias");
                }
            }
        }
    }
}
