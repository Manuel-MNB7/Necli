using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.DTOs;

public record ActualizarUsuario(  
         string Nombres,
         string Apellidos,
         string Email,
         string Contrasena,
         string Telefono

);

