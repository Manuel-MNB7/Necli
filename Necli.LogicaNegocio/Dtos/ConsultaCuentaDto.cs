using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.Dtos;
public record ConsultaCuentaDto
  (
      string Numero_cuenta,
      int Id_usuario,
      decimal Saldo,
      DateTime? Fecha_creacion
 );