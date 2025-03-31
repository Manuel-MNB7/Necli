using Microsoft.Data.SqlClient;
using Necli.Entidades;
using Necli.LogicaNegocio.Dtos;
using Necli.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.Services
{
    public class UsuarioService
    {

        public readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObtenerUsuario(int identificacion)
        {
            return _usuarioRepository.ConsultarUsuarioPorIdentificacion(identificacion);
        }


        public string ActualizarUsuario(int Id_usuario, string Nombres, string Apellidos, string Email, string Contrasena, string Telefono)
        {
            Usuario usuario = _usuarioRepository.ConsultarUsuarioPorIdentificacion(Id_usuario);

            if (usuario == null)
            {
                return "Usuario no encontrado.";
            }

            if (_usuarioRepository.ConsultarUsuarioPorTelefono(Telefono) is Usuario usuarioConMismoTelefono && usuarioConMismoTelefono.Id_usuarios != Id_usuario)
            {
                return "El número de teléfono ya está registrado. Por favor, ingrese otro número.";
            }

            if (_usuarioRepository.ObtenerUsuarioPorEmail(Email) is Usuario usuarioConMismoEmail && usuarioConMismoEmail.Id_usuarios != Id_usuario)
            {
                return "El email ya está registrado. Por favor, ingrese otro email.";
            }

            if (_usuarioRepository.ConsultarContrasenaUsuario(Contrasena, Id_usuario) is Usuario usuarioConMismaContrasena && usuarioConMismaContrasena.Id_usuarios != Id_usuario)
            {
                return "La contraseña ya está en uso. Por favor, elija una diferente.";
            }

            bool requiereVerificacion = false;
            string mensajeVerificacion = "Se ha actualizado correctamente el usuario. ";

            if (!usuario.Email.Equals(Email, StringComparison.OrdinalIgnoreCase))
            {
                requiereVerificacion = true;
                mensajeVerificacion += "El email ha sido cambiado y requiere verificación. ";
            }

            if (!usuario.Telefono.Equals(Telefono))
            {
                requiereVerificacion = true;
                mensajeVerificacion += "El teléfono ha sido cambiado y requiere verificación. ";
            }

            bool actualizado = _usuarioRepository.ActualizarUsuario(Id_usuario, Nombres, Apellidos, Email, Contrasena, Telefono);

            if (!actualizado)
            {
                return "No se pudo actualizar el usuario.";
            }

            return requiereVerificacion ? mensajeVerificacion : "Datos actualizados correctamente";
        }





    }
}