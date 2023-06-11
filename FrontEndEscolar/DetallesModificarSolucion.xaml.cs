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
    /// Lógica de interacción para DetallesModificarSolucion.xaml
    /// </summary>
    public partial class DetallesModificarSolucion : Window
    {
        ModificarSolucionAProblematica pantallaAnterior = new ModificarSolucionAProblematica();
        problematicaAcademica problematicaSeleccionada = new problematicaAcademica();
        public DetallesModificarSolucion()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(ModificarSolucionAProblematica pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        public void recibirProblematicaSeleccionada(problematicaAcademica problematicaSeleccionada)
        {
            this.problematicaSeleccionada = problematicaSeleccionada;
            mostrarProblematica();
        }

        public void mostrarProblematica()
        {
            lbTitulo.Content = problematicaSeleccionada.descripcion;
            lbDescripcion.Content = problematicaSeleccionada.descripcion;
            MessageBox.Show("La descripcion de la solucion es " +problematicaSeleccionada.descripcion);
            lbFechaRegistro.Content = problematicaSeleccionada.fechaRegistro.ToString().Substring(0, 10);
            lbNumeroIncidencias.Content = problematicaSeleccionada.numAlumnos;
            lbCategoria.Content = problematicaSeleccionada.categoria;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();

        }
    }
}
