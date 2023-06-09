﻿using ServiceReferenceControlEscolar;
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
        solucionProblematica solucionCorrespondiente = new solucionProblematica();
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
            obtenerSolucionAProblematica();
            mostrarProblematica();
        }

        public void mostrarProblematica()
        {
            lbTitulo.Content = problematicaSeleccionada.titulo;
            lbDescripcion.Content = problematicaSeleccionada.descripcion;
            lbFechaRegistro.Content = problematicaSeleccionada.fechaRegistro.ToString().Substring(0, 10);
            lbNumeroIncidencias.Content = problematicaSeleccionada.numAlumnos;
            lbCategoria.Content = problematicaSeleccionada.categoria;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            pantallaAnterior.IsEnabled = true;
            this.Close();

        }

        private async void obtenerSolucionAProblematica()
        {
            Service1Client servicio = new Service1Client();
            solucionCorrespondiente = await servicio.ObtenerSolucionAProblematicaAsync(problematicaSeleccionada.idProblematica);
            tbSolucion.Text = solucionCorrespondiente.descripcion;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(tbSolucion.Text == "")
            {
                MessageBox.Show("Ingrese una solucion", "Campos incompletos");
            } else if (tbSolucion.Text == solucionCorrespondiente.descripcion)
            {
                MessageBox.Show("No se ha modificado la solucion", "Campos sin cambios");
            }
            else
            {
                modificarSolucion();
            }
        }

        private async void modificarSolucion()
        {
            Service1Client servicio = new Service1Client();
            solucionCorrespondiente.descripcion = tbSolucion.Text;
            bool respuesta = await servicio.ModificarSolucionAProblematicaAsync(solucionCorrespondiente);
            if (respuesta)
            {
                MessageBox.Show("Se ha modificado la solución", "Modificación exitosa");
                pantallaAnterior.IsEnabled = true;
                pantallaAnterior.mostrarProblematicasConSolucion();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se ha podido modificar la solución", "Modificación fallida");
            }
        }
    }
}
