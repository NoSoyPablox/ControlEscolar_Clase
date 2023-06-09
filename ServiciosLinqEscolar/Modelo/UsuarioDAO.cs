﻿using System;
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
            //var usuarios = asdasdasd <--- no tiene tipo hasta que se le asigna algo 
            IQueryable<usuario> usuariosBD = from usuarioQuery in conexionBD.usuario
                                            select usuarioQuery;
            List <usuario> usuariosObtenidos = new List<usuario>();
            foreach (usuario usuario2 in usuariosBD)
            {
                var user3 = new usuario()
                {
                    idUsuario = usuario2.idUsuario,
                    nombre = usuario2.nombre,
                    apellidoPaterno = usuario2.apellidoPaterno
                };
                usuariosObtenidos.Add(user3);
            }
            return usuariosObtenidos;

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

        //Aqui son ya los del proyecto
        public static Boolean guardarTutorAcademico(usuario usuarioNuevo)
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
                    password = usuarioNuevo.password,
                    correoInstitucional = usuarioNuevo.correoInstitucional,
                    matricula = usuarioNuevo.matricula,
                    rol = usuarioNuevo.rol
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

        public static List<alumno> obtenerAlumnosPorTutor(int idUsuario)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            IQueryable<alumno> alumnosBD = from alumnoQuery in conexionBD.alumno
                                           where alumnoQuery.idTutor == idUsuario
                                           select alumnoQuery;
            List<alumno> alumnosRecuperados = new List<alumno>();
            foreach (alumno alumno in alumnosBD)
            {
                var alumno2 = new alumno()
                {
                    idAlumno = alumno.idAlumno,
                    nombre = alumno.nombre,
                    apellidoPaterno = alumno.apellidoPaterno,
                    apellidoMaterno = alumno.apellidoMaterno,
                    matricula = alumno.matricula,
                    idTutor = alumno.idTutor
                };
                alumnosRecuperados.Add(alumno2);
            }


            return alumnosRecuperados;
        }

        public static bool registrarFechasSesionTutoria()
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                tutoria tutoria = new tutoria
                {
                    fechaTutoria = DateTime.Today,
                    numeroSesion = 1
                };           
                conexionBD.tutoria.InsertOnSubmit(tutoria);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}