using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.DTOs
{
    public record RegistroTransacionDto(
       string NumeroCuentaOrigen,
       string NumeroCuentaDestino,
       decimal Monto
   );


}

