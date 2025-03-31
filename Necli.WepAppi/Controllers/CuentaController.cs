using Microsoft.AspNetCore.Mvc;
using Necli.LogicaNegocio;
using Necli.LogicaNegocio.Dtos;
using Necli.LogicaNegocio.Exceptions;

namespace Necli.Web.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly CuentasService _cuentasService;

        public CuentasController(CuentasService cuentasService)
        {
            _cuentasService = cuentasService;
        }

        [HttpPost("registrar")]
        public IActionResult RegistrarCuentaYUsuario([FromBody] RegistroCuentaDto dto)
        {
            try
            {
                _cuentasService.RegistrarCuentaYUsuario(dto);
                return Ok("Cuenta y usuario registrados exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    

     [HttpGet("{numeroCuenta}")]
        public IActionResult ConsultarCuenta(string numeroCuenta)
        {
            try
            {
                var cuenta = _cuentasService.ConsultarCuenta(numeroCuenta);

                if (cuenta == null)
                {
                    return NotFound(new { mensaje = "Cuenta no encontrada." });
                }

                return Ok(cuenta);
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado.", detalle = ex.Message });
            }
        }

        [HttpDelete("{numeroCuenta}")]
        public IActionResult EliminarCuenta(string numeroCuenta)
        {
            try
            {
                var eliminada = _cuentasService.EliminarCuenta(numeroCuenta);

                if (!eliminada)
                {
                    return NotFound(new { mensaje = "Cuenta no encontrada." });
                }

                return Ok(new { mensaje = "Cuenta eliminada exitosamente." });
            }
            catch (LogicaNegocioException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado.", detalle = ex.Message });
            }
        }

    }
}