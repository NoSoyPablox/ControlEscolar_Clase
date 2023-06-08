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
                usuario tutorRegistro = new usuario();
                tutorRegistro.matricula = tbMatricula.Text;
                tutorRegistro.nombre = tbNombre.Text;
                tutorRegistro.apellidoPaterno = tbApellidoPaterno.Text;
                tutorRegistro.apellidoMaterno = tbApellidoMaterno.Text;
                tutorRegistro.correoInstitucional = tbCorreo.Text;
                tutorRegistro.username = tbUsuario.Text;
                tutorRegistro.password = tbContrasena.Text;
                tutorRegistro.rol = "Tutor académico";
                registrarTutor(tutorRegistro);

                //Vaciar el texto de los campos de texto
                tbMatricula.Text = "";
                tbNombre.Text = "";
                tbApellidoPaterno.Text = "";
                tbApellidoMaterno.Text = "";
                tbCorreo.Text = "";
                tbUsuario.Text = "";
                tbContrasena.Text = "";
            }

        }


        private async void registrarTutor(usuario tutorRegistro)
        {
            using (var conexionServicios = new Service1Client())
            {
                bool resultado = await conexionServicios.GuardarTutorAcademicoAsync(tutorRegistro);
                if (resultado == true)
                {
                    MessageBox.Show("Se ha registrado el usuario");
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el usuario");
                }
            }
        }

        private async void verificarInicioSesion(string usuario, string password)
        {
            using (var conexionServicios = new Service1Client())
            {
                Mensaje resultado = await conexionServicios.IniciarSesionAsync(usuario, password);
                if (resultado.error == true)
                {
                    MessageBox.Show(resultado.message, "Credenciales incorrectas");
                }
                else
                {
                    MessageBox.Show("Bienvenido " + resultado.usuario.nombre + " " + resultado.usuario.rol + " al sistema", "Usuario Verificado");
                    PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
                    pantallaPrincipal.recibirUsuarioSesion(resultado.usuario);
                    pantallaPrincipal.mostrarOperaciones();
                    pantallaPrincipal.Show();
                    this.Close();
                }
            }
        }
    }
}
