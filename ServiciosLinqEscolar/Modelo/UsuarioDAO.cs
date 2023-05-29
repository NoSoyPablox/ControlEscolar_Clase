using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class UsuarioDAO
    {
        public static List<usuario> obtenerUsuarios()
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            //var usuarios = asdasdasd <--- no tiene tipo hasta que se le asigna algo asdasd
            IQueryable<usuario> usuariosBD = from usuarioQuery in conexionBD.usuario
                                            select usuarioQuery;

            return usuariosBD.ToList();

        }
        public static Mensaje iniciarSesion(string username, string password)
        {
            Mensaje mensaje = new Mensaje();
            DataClassesEscolarUVDataContext conexionBD = new DataClassesEscolarUVDataContext(global::System.Configuration.ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

            var usuario = (from userLogin in conexionBD.usuario
                           where userLogin.username == username &&
                           userLogin.password == password
                           select userLogin).FirstOrDefault();
            if (usuario!=null)
            {
                mensaje.error = false;
                mensaje.message = "El usuario fue encontrado";
                mensaje.usuario = usuario;
            }
            else
            {
                mensaje.error = true;
                mensaje.message = "El usuario no fue encontrado";
                mensaje.usuario = usuario;
            }
            return mensaje;
        }

        public static Boolean guardarUsuario(usuario usuarioNuevo)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                var usuario = new usuario()
                {
                    nombre = usuarioNuevo.nombre,
                    apellidoPaterno = usuarioNuevo.apellidoPaterno,
                    apellidoMaterno = usuarioNuevo.apellidoMaterno,
                    username = usuarioNuevo.username,
                    password = usuarioNuevo.password
                };//Permite construir con las propiedades que mandes, independiente al numero de argumentos que tenga el constructor
                conexionBD.usuario.InsertOnSubmit(usuario);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean editarUsuario(usuario UsuarioEdicion)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();

                var usuario = (from usuarioEdicion in conexionBD.usuario
                               where usuarioEdicion.idUsuario == UsuarioEdicion.idUsuario
                               select usuarioEdicion).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.nombre = UsuarioEdicion.nombre;
                    usuario.apellidoPaterno = UsuarioEdicion.apellidoPaterno;
                    usuario.apellidoMaterno = UsuarioEdicion.apellidoMaterno;
                    usuario.password = UsuarioEdicion.password;

                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool eliminarUsuario(int idUsuario)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                usuario usuarioEliminar = (from usuario in conexionBD.usuario
                                           where usuario.idUsuario == idUsuario
                                           select usuario).FirstOrDefault();

                if (usuarioEliminar!= null)
                {
                    conexionBD.usuario.DeleteOnSubmit(usuarioEliminar);
                    conexionBD.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }catch (Exception ex)
            {
                return false;
            }
        }

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["escolaruvConnectionString"].ConnectionString);

        }
    }
}