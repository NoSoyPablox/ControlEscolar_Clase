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
    /// Lógica de interacción para RegistrarSolucionAProblematica.xaml
    /// </summary>
    public partial class RegistrarSolucionAProblematica : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();

        public RegistrarSolucionAProblematica()
        {
            InitializeComponent();
        }

        //recibir ventana ventana anterior
        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        public void mostrarProblematicasSinSolucion()
        {
          ProblematicasSinSolucionViewModel problematicasSinSolucionViewModel = new ProblematicasSinSolucionViewModel();
          dgProblematicasSinSolucion.ItemsSource = problematicasSinSolucionViewModel.problematicasSinSolucion;
        }

        private void btnRegistrarSolucion_Click(object sender, RoutedEventArgs e)
        {
            if (dgProblematicasSinSolucion.SelectedIndex == -1)
            {
                  MessageBox.Show("Seleccione una problematica");
            }
            else
            {
                MessageBox.Show("Aqui se abre la ventana de registro de solucion");
                DetallesRegistrarSolucion detallesRegistrarSolucion = new DetallesRegistrarSolucion();
                detallesRegistrarSolucion.recibirVentanaAnterior(this);
                detallesRegistrarSolucion.recibirProblematicaSeleccionada((problematicaAcademica)dgProblematicasSinSolucion.SelectedItem);
                detallesRegistrarSolucion.Show();
                this.IsEnabled = false;
            }
        }
    }
}
