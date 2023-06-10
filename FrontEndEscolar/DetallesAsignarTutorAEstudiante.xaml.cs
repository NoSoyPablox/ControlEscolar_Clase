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
    /// Lógica de interacción para DetallesAsignarTutorAEstudiante.xaml
    /// </summary>
    public partial class DetallesAsignarTutorAEstudiante : Window
    {
        AsignarTutorAEstudiante pantallaAnterior = new AsignarTutorAEstudiante();
        alumno alumnoAsignar = new alumno();
        public DetallesAsignarTutorAEstudiante()
        {
            InitializeComponent();
            TutoresViewModel modelo = new TutoresViewModel();
            cbTutores.ItemsSource = modelo.tutoresBD;
        }

        public void recibirVentanaAnterior(AsignarTutorAEstudiante pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        public void recibirAlumno(alumno alumnoRecibido)
        {
            alumnoAsignar = alumnoRecibido;
            mostrarDatosAlumno();
        }

        private void mostrarDatosAlumno()
        {
            lbNombre.Content = alumnoAsignar.nombre;
            lbApellidoPaterno.Content = alumnoAsignar.apellidoPaterno;
            lbApellidoMaterno.Content = alumnoAsignar.apellidoMaterno;
            lbMatricula.Content = alumnoAsignar.matricula;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }
    }
}
