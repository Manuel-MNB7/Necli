using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.Entidades
{
   public class Transacion
    {

        public string Numero { get; set; } 
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string NumeroCuentaOrigen { get; set; }
        public string NumeroCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }

    }
}
