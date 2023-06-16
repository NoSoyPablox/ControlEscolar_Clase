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
    /// Lógica de interacción para ModificarSolucionAProblematica.xaml
    /// </summary>
    public partial class ModificarSolucionAProblematica : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();
        public ModificarSolucionAProblematica()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        public void mostrarProblematicasConSolucion()
        {
            ProblematicasConSolucionViewModel problematicasConSolucionViewModel = new ProblematicasConSolucionViewModel();
            dgProblematicasConSolucion.ItemsSource = problematicasConSolucionViewModel.problematicasConSolucion;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProblematicasConSolucion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una problematica", "Campos incompletos");
            }
            else
            {
                DetallesModificarSolucion detallesModificarSolucion = new DetallesModificarSolucion();
                detallesModificarSolucion.recibirVentanaAnterior(this);
                detallesModificarSolucion.recibirProblematicaSeleccionada((problematicaAcademica)dgProblematicasConSolucion.SelectedItem);
                detallesModificarSolucion.Show();
                this.IsEnabled = false;
            }
        }
    }
}
