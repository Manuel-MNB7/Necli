using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necli.WepApi.Entities;
using System.Net;
using Necli.WepApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Necli.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacionController : ControllerBase
    {

        [HttpPost]
        public ActionResult<Transacion> RealizarTransaccion([FromBody] Transacion transaccion)
        {
            try
            {
                if (transaccion is null)
                {
                    return BadRequest("La transacción no puede ser nula.");
                }

                var cuentaOrigen = UsuarioService.usuarios.FirstOrDefault(x => x.Numero == transaccion.NumeroCuentaOrigen);
                var cuentaDestino = UsuarioService.usuarios.FirstOrDefault(x => x.Numero == transaccion.NumeroCuentaDestinario);

                if (cuentaOrigen is null || cuentaDestino is null)
                {
                    return NotFound("Cuenta origen o destino no encontrada.");
                }

                if (transaccion.Monto < 1000 || transaccion.Monto > 5000000)
                {
                    return BadRequest("El monto debe estar entre $1.000 y $5.000.000 COP.");
                }

                if (cuentaOrigen.Saldo < transaccion.Monto)
                {
                    return BadRequest("Saldo insuficiente en la cuenta de origen.");
                }

                cuentaOrigen.Saldo -= transaccion.Monto;
                cuentaDestino.Saldo += transaccion.Monto;
                

                TransacionService.transacciones.Add(transaccion);



                return StatusCode((int)HttpStatusCode.Created, transaccion);



            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error interno del servidor: {ex.Message}");
            }

        }
    }
}
