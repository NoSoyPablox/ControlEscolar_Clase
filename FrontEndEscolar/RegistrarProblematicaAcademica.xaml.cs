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
    /// Lógica de interacción para RegistrarProblematicaAcademica.xaml
    /// </summary>
    public partial class RegistrarProblematicaAcademica : Window
    {
        LlenarReporteTutoria ventanaAnterior = new LlenarReporteTutoria();
        int numeroAlumnos = 0;

        public RegistrarProblematicaAcademica()
        {
            InitializeComponent();
        }

        public void recibirVentanaAnterior(LlenarReporteTutoria pantallaRecibida)
        {
            ventanaAnterior = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            ventanaAnterior.IsEnabled = true;
            this.Close();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitulo.Text == "" || tbDescripcion.Text == "" || tbNumeroIncidencias.Text == "" || cbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de llenar todos los campos");
            }
            else
            {
                validarNumeroEstudiantes();
                
            }
        }

        private void validarNumeroEstudiantes()
        {
            int numeroIncidencias;
            bool esNumero = int.TryParse(tbNumeroIncidencias.Text, out numeroIncidencias);
            if (!esNumero)
            {
                MessageBox.Show("Favor de ingresar un número en incidencias");
            } else if (numeroIncidencias > numeroAlumnos)
            {
                MessageBox.Show("El número de alumnos no puede ser mayor al número de alumnos que tiene asignados como tutorado");
            }else if (numeroIncidencias<1)
            {
                MessageBox.Show("El número de alumnos no puede ser menor a 1");
            }else
            {
                var problematicaAcademica = new problematicaAcademica()
                {
                    titulo = tbTitulo.Text,
                    descripcion = tbDescripcion.Text,
                    numAlumnos = Convert.ToInt32(tbNumeroIncidencias.Text),
                    categoria = cbCategoria.Text
                };
                ventanaAnterior.añadirProblematica(problematicaAcademica);
                MessageBox.Show("Problematica academica registrada");

                tbNumeroIncidencias.Text = "";
                tbTitulo.Text = "";
                tbDescripcion.Text = "";
                cbCategoria.SelectedIndex = -1;
            }
        }

        public void recibirNumeroAlumnos(int numeroAlumnosRecibidos)
        {
            numeroAlumnos = numeroAlumnosRecibidos;
        }
    }
}
