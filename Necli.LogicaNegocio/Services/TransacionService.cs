using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Necli.Entidades;
using Necli.LogicaNegocio.DTOs;
using Necli.LogicaNegocio.Exceptions;
using Necli.Persistencia;


namespace Necli.LogicaNegocio.Services
{
    public class TransacionService
    {
        private readonly CuentaRepository _cuentaRepository;
        private readonly TransacionRepository _transacionRepository;

        public TransacionService(CuentaRepository cuentaRepository, TransacionRepository transacionRepository)
        {
            _cuentaRepository = cuentaRepository;
            _transacionRepository = transacionRepository;
        }

        public void RealizarTransaccion(RegistroTransacionDto dto)
        {
            if (dto.NumeroCuentaOrigen == dto.NumeroCuentaDestino)
                throw new LogicaNegocioException("No se puede realizar una transacción a la misma cuenta.");

            using (var transactionScope = new TransactionScope())
            {
                var cuentaOrigen = _cuentaRepository.ConsultarCuentaPorNumero(dto.NumeroCuentaOrigen);
                var cuentaDestino = _cuentaRepository.ConsultarCuentaPorNumero(dto.NumeroCuentaDestino);

                if (cuentaOrigen == null || cuentaDestino == null)
                    throw new LogicaNegocioException("Una de las cuentas no existe.");

                if (dto.Monto < 1000 || dto.Monto > 5000000)
                    throw new LogicaNegocioException("El monto debe estar entre $1,000 y $5,000,000.");

                if (cuentaOrigen.Saldo < dto.Monto)
                    throw new LogicaNegocioException("Saldo insuficiente en la cuenta de origen.");

                string tipoTransaccion = (dto.NumeroCuentaOrigen == cuentaOrigen.Numero_cuenta) ? "salida" : "entrada";

                var transaccion = new Transacion
                {
                    Numero = _transacionRepository.GenerarNumeroUnico(),
                    Fecha = DateTime.Now,
                    NumeroCuentaOrigen = dto.NumeroCuentaOrigen,
                    NumeroCuentaDestino = dto.NumeroCuentaDestino,
                    Monto = dto.Monto,
                    Tipo = tipoTransaccion
                };

                _transacionRepository.RealizarTransaccion(transaccion);

                cuentaOrigen.Saldo -= dto.Monto;
                cuentaDestino.Saldo += dto.Monto;

                _cuentaRepository.ActualizarSaldo(cuentaOrigen.Numero_cuenta, cuentaOrigen.Saldo);
                _cuentaRepository.ActualizarSaldo(cuentaDestino.Numero_cuenta, cuentaDestino.Saldo);

                transactionScope.Complete();
            }
        }


        public ConsultaTransacionDto ConsultarTransaccion(string numeroCuenta)
        {
            if (string.IsNullOrEmpty(numeroCuenta))
            {
                throw new LogicaNegocioException("El número de cuenta no puede estar vacío.");
            }

            var transacion = _transacionRepository.ConsultarTransaccionPorNumero(numeroCuenta);

            if (transacion == null)
            {
                return null;
            }


            return new ConsultaTransacionDto(
                transacion.Numero,
                transacion.Fecha,
                transacion.NumeroCuentaOrigen,
                transacion.NumeroCuentaDestino,
                transacion.Monto,
                transacion.Tipo
            );
        }

    }
}
