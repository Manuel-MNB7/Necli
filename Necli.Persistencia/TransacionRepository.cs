using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Necli.Entidades;

namespace Necli.Persistencia
{

    public class TransacionRepository
    {
        private readonly string _cadena_conexion = "Server=Manuel_Narvaez\\SQLEXPRESS; Database=Necli; User ID=sa; Password=cecar; TrustServerCertificate=True;";

     
        public string GenerarNumeroUnico()
        {
            Random random = new Random();
            return random.Next(100000000, 999999999).ToString();
        }

        public void RealizarTransaccion(Transacion transaccion)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"
            INSERT INTO Transaccion (Numero, Fecha, Numero_cuenta_origen, Numero_cuenta_destino, Monto, Tipo) 
            VALUES (@Numero, @Fecha, @NumeroCuentaOrigen, @NumeroCuentaDestino, @Monto, @Tipo)";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Numero", transaccion.Numero);
                    comando.Parameters.AddWithValue("@Fecha", transaccion.Fecha);
                    comando.Parameters.AddWithValue("@NumeroCuentaOrigen", transaccion.NumeroCuentaOrigen);
                    comando.Parameters.AddWithValue("@NumeroCuentaDestino", transaccion.NumeroCuentaDestino);
                    comando.Parameters.AddWithValue("@Monto", transaccion.Monto);
                    comando.Parameters.AddWithValue("@Tipo", transaccion.Tipo);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }


        public Transacion ConsultarTransaccionPorNumero(string numeroTrsacion)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"
    SELECT TOP 1 Numero, Fecha, Numero_cuenta_origen, Numero_cuenta_destino, Monto, Tipo 
    FROM Transaccion 
    WHERE Numero = @NumeroTransaccion";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroTransaccion", numeroTrsacion);

                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Transacion
                            {
                                Numero = reader["Numero"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                NumeroCuentaOrigen = reader["Numero_cuenta_origen"].ToString(),
                                NumeroCuentaDestino = reader["Numero_cuenta_destino"].ToString(),
                                Monto = Convert.ToDecimal(reader["Monto"]),
                                Tipo = reader["Tipo"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }




    }
}
    

