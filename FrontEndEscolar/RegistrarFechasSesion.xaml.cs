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
    /// Lógica de interacción para RegistrarFechasSesion.xaml
    /// </summary>
    public partial class RegistrarFechasSesion : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();
        public RegistrarFechasSesion()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        public void cargarPeriodosEscolares()
        {
            PeriodoEscolarViewModel modelo = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = modelo.periodosEscolaresBD;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string fechaSesion1 = dpPrimeraSesion.Text;
            string fechaSesion2 = dpSegundaSesion.Text;
            string fechaSesion3 = dpTerceraSesion.Text;


            if (fechaSesion1 == "" || fechaSesion2 == "" || fechaSesion3 == "" || cbPeriodoEscolar.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos solicitados", "Campos incompletos");

            }
            else
            {
                validarFechas();
                periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
            }   
        }

        private async void registrarFechasSesion(string fecha1, string fecha2, string fecha3, int idPeriodo)
        {
            Service1Client servicio = new Service1Client();
            using (var conexionServicios = new Service1Client())
            {
                bool resultado = await conexionServicios.RegistrarFechasSesionTutoriaAsync(fecha1, fecha2, fecha3, idPeriodo);
                if (resultado == true)
                {
                    MessageBox.Show("Se han registrado las fechas" , "Registro exitoso");
                    dpPrimeraSesion.Text = "";
                    dpSegundaSesion.Text = "";
                    dpTerceraSesion.Text = "";
                    cbPeriodoEscolar.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Ya se han registrado fechas para este periodo, si desea modificarlas seleccione la opción modificar fechas del menu inicial", "Registro fallido");
                }
            }
        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        private void validarFechas()
        {
            periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
            DateTime inicioPeriodo = (DateTime)periodoSeleccionado.fechaInicio;
            DateTime finPeriodo = (DateTime)periodoSeleccionado.fechaFin;

            if (dpPrimeraSesion.SelectedDate < inicioPeriodo || dpPrimeraSesion.SelectedDate > finPeriodo)
            {
                MessageBox.Show("La fecha de la primera sesión no esta dentro del periodo escolar seleccionado", "Fechas inválidas");
                dpPrimeraSesion.Text = "";
            }else if (dpSegundaSesion.SelectedDate < dpPrimeraSesion.SelectedDate)
            {
                MessageBox.Show("La fecha de la segunda sesión no puede ser menor a la fecha de la primera sesion", "Fechas inválidas");
                dpSegundaSesion.Text = "";
            }else if (dpTerceraSesion.SelectedDate < dpSegundaSesion.SelectedDate)
            {
                MessageBox.Show("La fecha de la tercera sesión no puede ser menor a la fecha de la segunda sesion", "Fechas inválidas");
                dpTerceraSesion.Text = "";
            }else if (dpTerceraSesion.SelectedDate > finPeriodo)
            {
                MessageBox.Show("La fecha de la tercera sesión no puede ser mayor a la fecha de fin del periodo escolar", "Fechas inválidas");
                dpTerceraSesion.Text = "";
            }else if (dpTerceraSesion.SelectedDate > finPeriodo.AddDays(-7))
            {
                MessageBox.Show("La fecha de la ultima sesión debe ser al menos 7 dias antes del fin del periodo", "Fechas inválidas");
                dpTerceraSesion.Text = "";
            }
            else
            {
                string fechaSesion1 = dpPrimeraSesion.Text;
                string fechaSesion2 = dpSegundaSesion.Text;
                string fechaSesion3 = dpTerceraSesion.Text;
                registrarFechasSesion(fechaSesion1, fechaSesion2, fechaSesion3, periodoSeleccionado.idPeriodo);
            }
        }

        private void cbPeriodoEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbPeriodoEscolar.SelectedIndex != -1)
            {
                periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
                DateTime fechaInicioPeriodo = (DateTime)periodoSeleccionado.fechaInicio;
                DateTime fechaFinPeriodo = (DateTime)periodoSeleccionado.fechaFin;
                lbFechaInicioPeriodo.Content = fechaInicioPeriodo.ToString("dd-MM-yyyy");
                lbFechaFinPeriodo.Content = fechaFinPeriodo.ToString("dd-MM-yyyy");
            }
        }
    }
}
