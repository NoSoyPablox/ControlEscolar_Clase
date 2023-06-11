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
    /// Lógica de interacción para DetallesReporte.xaml
    /// </summary>
    public partial class DetallesReporte : Window
    {
        ConsultarReportePorTutor pantallaAnterior = new ConsultarReportePorTutor();
        public reporteDeTutoria reporteRecibido= new reporteDeTutoria();
        public DetallesReporte()
        {
            InitializeComponent();
        }
        public void recibirVentanaAnterior(ConsultarReportePorTutor pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        public void recibirReporte(reporteDeTutoria reporteRecibido)
        {
            this.reporteRecibido = reporteRecibido;
            lbFecha.Content = reporteRecibido.fecha.ToString().Substring(0,10);
            tbComentariosGenerales.Text = reporteRecibido.comentariosGenerales;
        }
    }
}
