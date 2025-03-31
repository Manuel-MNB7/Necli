using Necli.Entidades;
using Necli.LogicaNegocio.Dtos;
using Necli.Persistencia;

namespace Necli.LogicaNegocio
{
    public class CuentasService
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly CuentaRepository _cuentaRepository;

        public CuentasService(UsuarioRepository usuarioRepository, CuentaRepository cuentaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cuentaRepository = cuentaRepository;
        }

        public void RegistrarCuentaYUsuario(RegistroCuentaDto dto)
        {

            var usuarioExistentePorId = _usuarioRepository.ConsultarUsuarioPorIdentificacion(dto.Id_usuario);
            if (usuarioExistentePorId != null)
            {
                throw new InvalidOperationException($"El ID de usuario '{dto.Id_usuario}' ya está registrado. Intente con otro.");
            }

            var usuarioExistentePorEmail = _usuarioRepository.ObtenerUsuarioPorEmail(dto.Email);
            if (usuarioExistentePorEmail != null)
            {
                throw new InvalidOperationException($"El usuario con el email '{dto.Email}' ya está registrado.");
            }

            var usuarioExistentePorTelefono = _usuarioRepository.ConsultarUsuarioPorTelefono(dto.Telefono);
            if (usuarioExistentePorTelefono != null)
            {
                throw new InvalidOperationException($"El teléfono '{dto.Telefono}' ya está en uso. Intente con otro.");
            }

            var usuarioExistentePorContrasena = _usuarioRepository.ConsultarContrasenaUsuario(dto.Clave, dto.Id_usuario);
            if (usuarioExistentePorContrasena != null)
            {
                throw new InvalidOperationException("La contraseña ya está en uso. Intente con otra.");
            }

            var cuentaExistente = _cuentaRepository.ConsultarCuentaPorNumero(dto.Numero_cuenta);
            if (cuentaExistente != null)
            {
                throw new InvalidOperationException($"El número de cuenta '{dto.Numero_cuenta}' ya está registrado.");
            }

            var usuario = new Usuario
            {
                Id_usuarios = dto.Id_usuario,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Contrasena = dto.Clave,
                Telefono = dto.Telefono
            };

            bool usuarioRegistrado = _usuarioRepository.RegistrarUsuario(usuario);
            if (!usuarioRegistrado)
            {
                throw new InvalidOperationException("Error al registrar el usuario, la cuenta no será creada.");
            }

            var cuenta = new Cuenta
            {
                Numero_cuenta = dto.Numero_cuenta,
                Id_usuario = usuario.Id_usuarios,
                Saldo = dto.Saldo
            };

            _cuentaRepository.RegistrarCuenta(cuenta);
        }

        public ConsultaCuentaDto ConsultarCuenta(string numeroCuenta)
        {
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                throw new ArgumentException("El número de cuenta no puede estar vacío.", nameof(numeroCuenta));
            }

            if (!long.TryParse(numeroCuenta, out var numeroCuentaLong))
            {
                throw new ArgumentException("El número de cuenta debe ser un valor numérico válido.", nameof(numeroCuenta));
            }

            var cuenta = _cuentaRepository.ConsultarCuentaPorNumero(numeroCuenta);


            if (cuenta == null)
            {
                return null;
            }

            return new ConsultaCuentaDto(
                cuenta.Numero_cuenta,
                cuenta.Id_usuario,
                cuenta.Saldo,
                cuenta.Fecha_creacion
            );
        }


        public bool EliminarCuenta(string numeroCuenta)
        {
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                throw new ArgumentException("El número de cuenta no puede estar vacío.", nameof(numeroCuenta));
            }

            if (!long.TryParse(numeroCuenta, out var numeroCuentaLong))
            {
                throw new ArgumentException("El número de cuenta debe ser un valor numérico válido.", nameof(numeroCuenta));
            }


            var cuenta = _cuentaRepository.ConsultarCuentaPorNumero(numeroCuenta);

            if (cuenta == null)
            {
                return false;
            }

            if (cuenta.Saldo > 50000)
            {
                throw new InvalidOperationException("No se puede eliminar la cuenta porque su saldo es mayor a $50,000.");
            }

            return _cuentaRepository.EliminarCuenta(numeroCuentaLong);
        }




    }
}
