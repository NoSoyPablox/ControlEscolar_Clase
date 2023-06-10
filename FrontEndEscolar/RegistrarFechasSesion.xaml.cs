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

            //si los campos dp estan vacios mandar mensaje de error
            if (fechaSesion1 == "" || fechaSesion2 == "" || fechaSesion3 == "" || cbPeriodoEscolar.SelectedIndex == -1)
            {
                //quiero saber si el combobox no tiene seleccionado un periodo escolar

                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                //obtener el id del periodo escolar seleccionado
                periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
                int idPeriodo = periodoSeleccionado.idPeriodo;

                //registrar las fechas de sesion
                registrarFechasSesion(fechaSesion1, fechaSesion2, fechaSesion3, idPeriodo);
            }   
        }

        private async void registrarFechasSesion(string fecha1, string fecha2, string fecha3, int idPeriodo)
        {
            //instanciar el servicio de control escolar
            Service1Client servicio = new Service1Client();
            using (var conexionServicios = new Service1Client())
            {
                bool resultado = await conexionServicios.RegistrarFechasSesionTutoriaAsync(fecha1, fecha2, fecha3, idPeriodo);
                if (resultado == true)
                {
                    MessageBox.Show("Se han registrado las fechas");
                    dpPrimeraSesion.Text = "";
                    dpSegundaSesion.Text = "";
                    dpTerceraSesion.Text = "";
                    //Quitar la seleccion del combobox
                    cbPeriodoEscolar.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se han podido registrar las fechas");
                }
            }
        }


        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }
    }
}
