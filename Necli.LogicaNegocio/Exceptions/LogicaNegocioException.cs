using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Necli.LogicaNegocio.Exceptions
{
    public class LogicaNegocioException : Exception
    {
        public LogicaNegocioException()
        {
        }

        public LogicaNegocioException(string? message) : base(message)
        {
        }

        public LogicaNegocioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
