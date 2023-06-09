﻿using FrontEndEscolar.Modelo;
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
    /// Lógica de interacción para AsignarTutorAEstudiante.xaml
    /// </summary>
    public partial class AsignarTutorAEstudiante : Window
    {
        PantallaPrincipal pantallaAnterior = new PantallaPrincipal();

        public AsignarTutorAEstudiante()
        {
            InitializeComponent();
            AlumnosViewModel modelo = new AlumnosViewModel();
            dgAlumnos.ItemsSource = modelo.alumnosBD;
        }

        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
        {
            pantallaAnterior = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();
        }

        private void btnAsignarTutor_Click(object sender, RoutedEventArgs e)
        {
            alumno alumnoSeleccionado = (alumno)dgAlumnos.SelectedItem;
            if (alumnoSeleccionado != null)
            {
                DetallesAsignarTutorAEstudiante detallesAsignarTutorAEstudiante = new DetallesAsignarTutorAEstudiante();
                detallesAsignarTutorAEstudiante.recibirVentanaAnterior(this);
                detallesAsignarTutorAEstudiante.recibirAlumno(alumnoSeleccionado);
                detallesAsignarTutorAEstudiante.Show();
                this.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione un alumno", "Campos incompletos");
            }
        }

        public void actualizarAlumnosSinTutor()
        {
            AlumnosViewModel modelo = new AlumnosViewModel();
            dgAlumnos.ItemsSource = modelo.alumnosBD;
        }
    }
}
