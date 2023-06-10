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
    /// Lógica de interacción para LlenarReporteTutoria.xaml
    /// </summary>
    public partial class LlenarReporteTutoria : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();

        public LlenarReporteTutoria()
        {
            InitializeComponent();
            PeriodoEscolarViewModel modelo = new PeriodoEscolarViewModel();
            cbPeriodoEscolar.ItemsSource = modelo.periodosEscolaresBD;
        }

        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        usuario usuarioSesion = new usuario();
        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
        }

        public void obtenerAlumnos(int idUsuario)
        {
            AlumnoViewModel modelo = new AlumnoViewModel(usuarioSesion.idUsuario);
            dgEstudiantes.ItemsSource = modelo.alumnosBD;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //comprobar que los combobox no esten sin seleccion
            if (cbPeriodoEscolar.SelectedIndex == -1 || cbTutorias.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                //obtener el id de la tutoria seleccionada
                tutoria tutoriaSeleccionada = cbTutorias.SelectedItem as tutoria;
                //Quiero obtener los objetos alumnoLocal de la tabla que tengan el checkbox asistio seleccionado
                int contadorAsistentes = 0;
                //Lista de enteros que guardara los id de los alumnos que asistieron
                //contar cuantos alumnos tienen la casilla asistio seleccionada
                foreach (AlumnoLocal alumno in dgEstudiantes.ItemsSource)
                {
                    if (alumno.isSelected == true)
                    {
                        contadorAsistentes++;
                    }
                }
                //Crear un arreglo de enteros que guarde los id de los alumnos que asistieron
                int[] idAlumnosAsistentes = new int[contadorAsistentes];
                //metodo que obtiene los id de los alumnos que asistieron y los mete en el arreglo
                int contador = 0;
                foreach (AlumnoLocal alumno in dgEstudiantes.ItemsSource)
                {
                    if (alumno.isSelected == true)
                    {
                        idAlumnosAsistentes[contador] = alumno.idAlumno;
                        contador++;
                    }
                }
                //MessageBox que escriba en pantalla solo el nombre de los alumnos que asistieron
                MessageBox.Show("El numero de alumnos que asistieron es: " + contadorAsistentes);

                
            }
        }

        private void btnAgregarProblematica_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        private void cbPeriodoEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPeriodoEscolar.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un periodo escolar");
            }
            else
            {
                periodoEscolar periodoSeleccionado = cbPeriodoEscolar.SelectedItem as periodoEscolar;
                obtenerTutorias(periodoSeleccionado.idPeriodo);
            }
        }

        private void obtenerTutorias(int idUsuario)
        {
            TutoriasViewModel modelo = new TutoriasViewModel(idUsuario);
            cbTutorias.ItemsSource = modelo.tutoriasBD;
        }
    }
}
