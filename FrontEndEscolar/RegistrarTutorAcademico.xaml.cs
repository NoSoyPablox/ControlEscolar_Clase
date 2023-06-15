using ServiceReferenceControlEscolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private static readonly Regex regexLetras = new Regex("^[a-zA-Z]*$");
        private static readonly Regex regexLetrasConEspacios = new Regex("^[a-zA-Z ]*$");
        private static readonly Regex regexNumeros = new Regex("^[0-9]*$");

        public RegistrarTutorAcademico()
        {
            InitializeComponent();
        }
        PantallaPrincipal pantallaPrincipal = null;
        public void recibirVentanaAnterior(PantallaPrincipal pantallaRecibida)
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
            if (string.IsNullOrEmpty(tbMatricula.Text) == true || string.IsNullOrEmpty(tbNombre.Text) || string.IsNullOrEmpty(tbApellidoPaterno.Text) == true || string.IsNullOrEmpty(tbApellidoMaterno.Text) == true || string.IsNullOrEmpty(tbCorreo.Text) == true || string.IsNullOrEmpty(tbUsuario.Text) == true || string.IsNullOrEmpty(tbContrasena.Text) == true || string.IsNullOrEmpty(tbTelefono.Text) == true || cbCorreo.SelectedIndex == -1)
            {
                MessageBox.Show("Complete los campos solicitados", "Campos incompletos");
            }
            else
            {
                validarCampos();
            }
        }


        private async void registrarTutor(usuario tutorRegistro)
        {
            using (var conexionServicios = new Service1Client())
            {
                bool resultado = await conexionServicios.GuardarTutorAcademicoAsync(tutorRegistro);
                if (resultado == true)
                {
                    MessageBox.Show("Se ha registrado el usuario", "Registro exitoso");
                    tbMatricula.Text = "";
                    tbNombre.Text = "";
                    tbApellidoPaterno.Text = "";
                    tbApellidoMaterno.Text = "";
                    tbCorreo.Text = "";
                    tbUsuario.Text = "";
                    tbContrasena.Text = "";
                    tbTelefono.Text = "";
                    cbCorreo.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el usuario", "Registro fallido");
                }
            }
        }

        private void validarCampos()
        {
            if (!regexLetras.IsMatch(tbNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre válido, solo letras", "Formato no válido");
            }else if (!regexLetrasConEspacios.IsMatch(tbApellidoPaterno.Text))
            {
                MessageBox.Show("Ingrese un apellido paterno válido, solo letras", "Formato no válido");
            }else if (!regexLetrasConEspacios.IsMatch(tbApellidoMaterno.Text))
            {
                MessageBox.Show("Ingrese un apellido materno válido, solo letras", "Formato no válido");
            }else if (!regexNumeros.IsMatch(tbTelefono.Text))
            {
                MessageBox.Show("Ingrese un numero de telefono válido, solo numeros", "Formato no válido");
            }else if(tbTelefono.Text.Length > 9)
            {
                MessageBox.Show("El numero no puede ser mayor a 9 digitos", "Formato no válido");
            }
            else
            {
                usuario tutorRegistro = new usuario();
                tutorRegistro.matricula = tbMatricula.Text;
                tutorRegistro.nombre = tbNombre.Text;
                tutorRegistro.apellidoPaterno = tbApellidoPaterno.Text;
                tutorRegistro.apellidoMaterno = tbApellidoMaterno.Text;
                string correoCompleto = tbCorreo.Text + cbCorreo.Text;
                tutorRegistro.correoInstitucional = correoCompleto;
                tutorRegistro.username = tbUsuario.Text;
                tutorRegistro.password = tbContrasena.Text;
                tutorRegistro.numeroTelefonico = tbTelefono.Text;
                tutorRegistro.rol = "Tutor academico";
                registrarTutor(tutorRegistro);
            }
        }
    }
}
