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
        public LlenarReporteTutoria()
        {
            InitializeComponent();
        }
        usuario usuarioSesion = new usuario();
        public void recibirUsuarioSesion(usuario usuarioRecibido)
        {
            usuarioSesion = usuarioRecibido;
        }

        public void obtenerAlumnos(int idUsuario)
        {
            //aqui se llama al metodo del servicio para obtener los alumnos del tutor haciendo uso de su idTutor
            Service1Client servicio = new Service1Client();
            //List<estudiante> listaEstudiantes = servicio.ObtenerEstudiantesPorTutor(idUsuario).ToList();
        }
    }
}
