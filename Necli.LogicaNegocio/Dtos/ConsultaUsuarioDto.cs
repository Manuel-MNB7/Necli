using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.DTOs
{
   public record ConsultaUsuarioDto(
         Guid Id_usuarios,
         string Nombres,
         string apellidos, 
         string email,
         string Contrasena,
         string telefono
        );
    
}
