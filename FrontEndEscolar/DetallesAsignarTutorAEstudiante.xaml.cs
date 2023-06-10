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

        private async void btnAsignar_Click(object sender, RoutedEventArgs e)
        {
            //aqui hacer uso del servicio para asignar el tutor al alumno
            usuario tutorSeleccionado = (usuario)cbTutores.SelectedItem;
            if (tutorSeleccionado != null)
            {
                var conexionServicios = new Service1Client();
                if (conexionServicios != null)
                {
                    bool resultado = await conexionServicios.AsignarTutorAlumnoAsync(alumnoAsignar.idAlumno, tutorSeleccionado.idUsuario);
                    if (resultado)
                    {
                        MessageBox.Show("Tutor asignado correctamente");
                        pantallaAnterior.IsEnabled = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al asignar tutor");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un tutor");
            }
        }
    }
}
