using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
namespace Necli.WepAppi.Controllers;
using Necli.LogicaNegocio.Services;
using Necli.LogicaNegocio.DTOs;
using Necli.LogicaNegocio.Exceptions;

[Route("api/[controller]")]
[ApiController]
public class TransaccionController : ControllerBase
{
    private readonly TransacionService _transaccionService;

    public TransaccionController(TransacionService transaccionService)
    {
        _transaccionService = transaccionService;
    }

    [HttpPost]
    public IActionResult RealizarTransaccion([FromBody] RegistroTransacionDto dto)
    {
        try
        {
            _transaccionService.RealizarTransaccion(dto);
            return Ok("Transacción realizada exitosamente.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{numeroCuenta}")]
    public IActionResult ConsultarTransaccion(string numeroCuenta)
    {
        try
        {
            var transaccion = _transaccionService.ConsultarTransaccion(numeroCuenta);

            if (transaccion == null)
            {
                return NotFound(new { mensaje = "No se encontraron transacciones para la cuenta especificada." });
            }

            return Ok(transaccion);
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

