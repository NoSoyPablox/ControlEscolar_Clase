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
    /// Lógica de interacción para DetallesRegistrarSolucion.xaml
    /// </summary>
    public partial class DetallesRegistrarSolucion : Window
    {
        RegistrarSolucionAProblematica pantallaAnterior = new RegistrarSolucionAProblematica();
        problematicaAcademica problematicaARegistrar = new problematicaAcademica();
        public DetallesRegistrarSolucion()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(RegistrarSolucionAProblematica pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        public void recibirProblematicaSeleccionada(problematicaAcademica problematicaRecibida)
        {
            problematicaARegistrar = problematicaRecibida;
            mostrarDetallesProblematica();
        }

        public void mostrarDetallesProblematica()
        {
            lbTitulo.Content = problematicaARegistrar.titulo;
            lbDescripcion.Content = problematicaARegistrar.descripcion;
            lbCategoria.Content = problematicaARegistrar.categoria;
            lbFechaRegistro.Content = problematicaARegistrar.fechaRegistro.ToString().Substring(0,10);
            lbNumeroIncidencias.Content = problematicaARegistrar.numAlumnos;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }
    }
}
