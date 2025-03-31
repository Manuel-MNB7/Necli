using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.Dtos;


public record RegistroCuentaDto(
    string Numero_cuenta,
    int Id_usuario, 
    decimal Saldo,
    string Nombres,
    string Apellidos,
    string Email,
    string Clave,
    string Telefono
);
