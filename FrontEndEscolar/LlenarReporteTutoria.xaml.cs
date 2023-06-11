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
        bool registradoAntes = false;
        List <problematicaAcademica> problematicaAcademicas = new List<problematicaAcademica>();

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
            if (cbPeriodoEscolar.SelectedIndex == -1 || cbTutorias.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                registradaAntes();
            }
        }

        private void btnAgregarProblematica_Click(object sender, RoutedEventArgs e)
        {
            RegistrarProblematicaAcademica registrarProblematica = new RegistrarProblematicaAcademica();
            registrarProblematica.recibirVentanaAnterior(this);
            //obtener el numero de alumnos que tiene datagrid
            int numeroAlumnos = dgEstudiantes.Items.Count;
            registrarProblematica.recibirNumeroAlumnos(numeroAlumnos);
            registrarProblematica.Show();
            this.IsEnabled = false;
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


        private async void registrarAsistencia()
        {
            tutoria tutoriaSeleccionada = cbTutorias.SelectedItem as tutoria;

            //Arreglo de enteros que guarde los id de los alumnos que asistieron
            List<int> idAsistentes = new List<int>();
            List<int> idNoAsistentes = new List<int>();

            foreach (AlumnoLocal alumno in dgEstudiantes.ItemsSource)
            {
                if (alumno.isSelected == true)
                {
                    idAsistentes.Add(alumno.idAlumno);
                }else
                {
                    idNoAsistentes.Add(alumno.idAlumno);
                }
            }
            MessageBox.Show("Se guardo la asistencia de " + idAsistentes.Count + " alumnos");
            Service1Client servicio = new Service1Client();
            //int que obtenga el id de la tutoria seleccionada
            int idTutoria = (cbTutorias.SelectedItem as tutoria).idTutoria;
            reporteDeTutoria reporteCreado = await servicio.ObtenerReporteCreadoAsync(idTutoria, usuarioSesion.idUsuario);
            bool registrarTutorias = await servicio.RegistarListaAsistenciaAReporteAsync(reporteCreado.idReporte, idAsistentes.ToArray(), idNoAsistentes.ToArray());
            if (registrarTutorias == true)
            {
                MessageBox.Show("Se registro la asistencia de los alumnos");
                registrarProblematicas(reporteCreado.idReporte);
            }
            else
            {
                MessageBox.Show("No se pudo registrar la asistencia de los alumnos");
            }

        }

        private async void registrarProblematicas(int idReporte)
        {
            Service1Client servicio = new Service1Client();
            int idTutoria = (cbTutorias.SelectedItem as tutoria).idTutoria;
            reporteDeTutoria reporteCreado = await servicio.ObtenerReporteCreadoAsync(idTutoria, usuarioSesion.idUsuario);
            bool registrarTutorias = await servicio.RegistrarProblematicasAcademicasAsync(problematicaAcademicas.ToArray(), reporteCreado.idReporte);
            if (registrarTutorias == true)
            {
                MessageBox.Show("Se registraron las problematicas academicas");
            }
            else
            {
                MessageBox.Show("No se pudieron registrar las problematicas academicas");
            }
        }

        private async void registradaAntes()
        {

            Service1Client servicio = new Service1Client();
            int idTutoria = (cbTutorias.SelectedItem as tutoria).idTutoria;
            registradoAntes = await servicio.VerificarRegistroReportePorTutoriaAsync(idTutoria, usuarioSesion.idUsuario);

            if (registradoAntes == true)
            {
                MessageBox.Show("Ya se ha registrado un reporte de tutoria para esta tutoria");
                registradoAntes = true;
            }
            else
            {
                bool estaVigente = await servicio.VerificarFechaCierreVigenteAsync(idTutoria);
                if (estaVigente == true)
                {
                    MessageBox.Show("La fecha de cierre de este reporte de tutoria esta vigente");
                    registrarReporteTutoria();

                }
                else
                {
                    MessageBox.Show("La fecha actual esta fuera del periodo de entrega de esta sesion de tutoria");
                }
            }
        }

        private void cbTutorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void añadirProblematica(problematicaAcademica problematica)
        {
            problematicaAcademicas.Add(problematica);
        }

        private async void registrarReporteTutoria()
        {
            Service1Client servicio = new Service1Client();
            tutoria tutoriaSeleccionada = cbTutorias.SelectedItem as tutoria;
            int numeroSesion = (int)tutoriaSeleccionada.numeroSesion;
            int idTutoria = (int)tutoriaSeleccionada.idTutoria;
            bool registrado = await servicio.RegistrarReporteTutoriaAsync(tbComentariosGenerales.Text,numeroSesion, usuarioSesion.idUsuario, idTutoria);
            if (registrado == true)
            {
                MessageBox.Show("Se ha registrado el reporte de tutoria");
                registrarAsistencia();
            }
            else
            {
                MessageBox.Show("No se ha podido registrar el reporte de tutoria");
            }
        }
    }
}
