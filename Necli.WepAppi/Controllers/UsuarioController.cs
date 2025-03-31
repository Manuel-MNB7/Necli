using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necli.Entidades;
using Necli.LogicaNegocio.DTOs;
using Necli.LogicaNegocio.Services;



namespace Necli.WepAppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{identificacion}")]
        public IActionResult ConsultarUsuario(int identificacion)
        {
            try
            {
                var usuario = _usuarioService.ObtenerUsuario(identificacion);

                if (usuario == null)
                {
                    return NotFound(new { mensaje = "Usuario no encontrado." });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado.", detalle = ex.Message });
            }
        }

        [HttpPut("ActualizarUsuario/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] ActualizarUsuario usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Datos inválidos.");
            }

            string resultado = _usuarioService.ActualizarUsuario(
                id, 
                usuarioDto.Nombres,
                usuarioDto.Apellidos,
                usuarioDto.Email,
                usuarioDto.Contrasena,
                usuarioDto.Telefono
            );

            return Ok(new { mensaje = resultado });
        }





    }
}
