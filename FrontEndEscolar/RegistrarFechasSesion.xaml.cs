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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string fechaSesion1 = dpPrimeraSesion.Text;
            string fechaSesion2 = dpSegundaSesion.Text;
            string fechaSesion3 = dpTerceraSesion.Text;

            MessageBox.Show("Se han guardado las fechas de sesión: fecha1: " + fechaSesion1 + " fecha2: " + fechaSesion2 + " fecha3" + fechaSesion3 );

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }
    }
}
