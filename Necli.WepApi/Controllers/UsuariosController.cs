using Microsoft.AspNetCore.Mvc;
using Necli.WepApi.Entities;
using System.Net;
using Necli.WepApi.Services;


namespace Necli.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
      
        [HttpPost]

        public ActionResult<Usuario> Crear([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Nombre == "" )
                {

                    return BadRequest("el nombre y los apellidos no pueden ser nulo ");
                }
                if (usuario.Apellidos == "")
                {

                    return BadRequest("el nombre y los apellidos no pueden ser nulo ");
                }
                if (!usuario.Correo.Contains("@"))
                {
                    return BadRequest("El correo electrónico no es válido.");
                }

                if (usuario.Numero.Length != 10)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "el numero debe tener 10 digitos sin utilizar el +57");
                }

                if (UsuarioService.usuarios.Any(u => u.Id == usuario.Id))
                {
                    return BadRequest("La identificación del usuario ya está registrada.");
                }
                if (UsuarioService.usuarios.Any(u => u.Numero == usuario.Numero))
                {
                    return BadRequest("el numero yaa esta registrado del usuario ya está registrada.");
                }

                if (UsuarioService.usuarios.Any(u => u.Correo == usuario.Correo))
                {
                    return BadRequest("El correo electrónico ya está registrado.");
                }

                if (UsuarioService.usuarios.Any(u => u.Numero == usuario.Numero))
                {
                    return BadRequest("El número de teléfono ya está registrado por favor ingrese otro numero.");
                }
                UsuarioService.usuarios.Add(usuario);
                return StatusCode((int)HttpStatusCode.Created, "El usuario se registro exitosamente."); ;
                
            }
            catch (Exception ex) {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error interno del servidor y el error es {ex}");
            }


        }

        [HttpGet("{Numero}")]

        public ActionResult<Usuario> Leer(string Numero)
        {        
            

               try
            {
                    var UsuarioEncontrado = UsuarioService.usuarios.FirstOrDefault(x => x.Numero == Numero);

                if (UsuarioEncontrado is null)
                {
                    return NotFound(new { mensaje = "Usuario no encontrado" });
                }
                else { return Ok(UsuarioEncontrado); }


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,  $"Error interno del servidor y el error es {ex}"); 
            }

        }


        [HttpPut("{numero}")]
        public ActionResult<Usuario> Actualizar(string numero, [FromBody] Usuario usuario)
        {
            try
            {
                var UsuarioEncontrado = UsuarioService.usuarios.FirstOrDefault(x => x.Numero == numero);

                if (UsuarioEncontrado is null)
                {

                    return NotFound();
                }
                else

                {
                    if (usuario.Id != UsuarioEncontrado.Id)
                    {
                        if (UsuarioService.usuarios.Any(u => u.Id == usuario.Id))
                        {
                        }
                        return BadRequest("La identificación del usuario ya está registrada.");
                    }
                    if (usuario.Nombre == "")
                    {

                        return BadRequest("el nombre y los apellidos no pueden ser nulo ");
                    }
                    if (usuario.Apellidos == "")
                    {

                        return BadRequest("el nombre y los apellidos no pueden ser nulo ");
                    }

                    if (usuario.Numero != UsuarioEncontrado.Numero) { 
                     if (UsuarioService.usuarios.Any(u => u.Numero == usuario.Numero))
                    {
                        return BadRequest("El número de teléfono ya está registrado por favor ingrese otro numero.");
                    }
                    }

                    if (usuario.Correo != UsuarioEncontrado.Correo)
                    {
                        if (UsuarioService.usuarios.Any(u => u.Correo == usuario.Correo))
                        {
                            return BadRequest("El correo electrónico ya está registrado.");
                        }
                    }


                    if (!usuario.Correo.Contains("@"))
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, "El correo electrónico no es válido.");
                    }
                    else
                    {
                        UsuarioEncontrado.Correo = usuario.Correo;
                    }

                    if (usuario.Numero.Length != 10)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, "el numero debe tener 10 digitos sin utilizar el +57");
                    }
                    else
                    {

                        UsuarioEncontrado.Numero = usuario.Numero;

                    }
                    if (usuario.Saldo < 0)
                    {
                        return StatusCode((int)HttpStatusCode.BadRequest, "el saldo no puede ser negativo");
                    }
                    else { UsuarioEncontrado.Saldo = usuario.Saldo; }

                        UsuarioEncontrado.Nombre = usuario.Nombre;
                    UsuarioEncontrado.Correo = usuario.Correo;
                    UsuarioEncontrado.Contraseña = usuario.Contraseña;


                    return Ok(UsuarioEncontrado);

                } }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error interno del servidor y el error es {ex}");
            }
        }

        [HttpDelete("{numero}")]
        public ActionResult<Usuario> Eliminar(string numero)
        {
            try
            {
                var UsuarioEncontrado = UsuarioService.usuarios.FirstOrDefault(x => x.Numero == numero);

                if (UsuarioEncontrado is null)
                {

                    return NotFound("No se pudo eliminar el numero no esta registrado");
                }
                else
                {
                    UsuarioService.usuarios.Remove(UsuarioEncontrado);
                    return Ok("Se elimino con exito ");

                }


            }
            catch (Exception ex) {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Error interno del servidor y el error es {ex}");
            }
        }







        }




}

