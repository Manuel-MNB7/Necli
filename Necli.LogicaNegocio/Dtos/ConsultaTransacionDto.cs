using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.DTOs;

   public record ConsultaTransacionDto
    (
        string Numero,
        DateTime Fecha,
        string Numero_cuenta_origen,
        string Numero_cuenta_destino,
        decimal Monto,
        string Tipo
    );

