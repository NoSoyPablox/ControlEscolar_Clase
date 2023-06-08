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
    /// Lógica de interacción para RegistrarTutorAcademico.xaml
    /// </summary>
    public partial class RegistrarTutorAcademico : Window
    {
        public RegistrarTutorAcademico()
        {
            InitializeComponent();
        }
        PantallaPrincipal pantallaPrincipal = null;
        public void recibirVentanaAnterior (PantallaPrincipal pantallaRecibida)
        {
            pantallaPrincipal = pantallaRecibida;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            pantallaPrincipal.IsEnabled = true;
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMatricula.Text) == true || string.IsNullOrEmpty(tbNombre.Text) || string.IsNullOrEmpty(tbApellidoPaterno.Text) == true || string.IsNullOrEmpty(tbApellidoMaterno.Text) == true || string.IsNullOrEmpty(tbCorreo.Text) == true || string.IsNullOrEmpty(tbUsuario.Text) == true || string.IsNullOrEmpty(tbContrasena.Text) == true)
            {
                MessageBox.Show("Llene los campos solicitados");
            }
            else
            {
                //Vaciar el texto de los campos de texto
                tbMatricula.Text = "";
                tbNombre.Text = "";
                tbApellidoPaterno.Text = "";
                tbApellidoMaterno.Text = "";
                tbCorreo.Text = "";
                tbUsuario.Text = "";
                tbContrasena.Text = "";
                MessageBox.Show("Tutor académico registrado");

            }

        }
    }
}
