using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.Entidades
{
    public class Usuario
    {
        

        public  int Id_usuarios { get; set; }
        public required string Nombres { get; set; } 
        public required string Apellidos { get; set; }
        public required string Email { get; set; }
        public required string Contrasena { get; set; } 
        public required string Telefono { get; set; }
    }

}

