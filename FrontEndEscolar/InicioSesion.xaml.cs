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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontEndEscolar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string usuario = tbUsuario.Text;
            string contrasena = pbContrasena.Password; //password.password
            if (usuario.Length > 0 && contrasena.Length>0){
                verificarInicioSesion(usuario, contrasena);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña requeridos");
            }
        }
        private async void verificarInicioSesion(string usuario, string password)
        {
            using(var conexionServicios = new Service1Client())
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

        private void pbContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnIniciarSesion_Click(sender, e);
            }
        }
    }
}
