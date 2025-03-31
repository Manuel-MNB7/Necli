using System;
using Microsoft.Data.SqlClient;
using Necli.Entidades;

namespace Necli.Persistencia
{
    public class CuentaRepository
    {
        private readonly string _cadena_conexion = "Server=Manuel_Narvaez\\SQLEXPRESS; Database=Necli; User ID=sa; Password=cecar; TrustServerCertificate=True;";

        public bool RegistrarCuenta(Cuenta cuenta)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"INSERT INTO Cuenta (Numero_cuenta, Id_usuario, Saldo, Fecha_creacion) 
                               VALUES (@Numero_cuenta, @Id_usuario, @Saldo, @Fecha_creacion)";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Numero_cuenta", cuenta.Numero_cuenta);
                    comando.Parameters.AddWithValue("@Id_usuario", cuenta.Id_usuario);
                    comando.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                    comando.Parameters.AddWithValue("@Fecha_creacion", DateTime.Now);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }


        public Cuenta ConsultarCuentaPorNumero(string numeroCuenta)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"SELECT Numero_cuenta, Id_usuario, Saldo, Fecha_creacion 
                           FROM Cuenta 
                           WHERE Numero_cuenta = @NumeroCuenta";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@NumeroCuenta", numeroCuenta);
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cuenta
                            {
                                Numero_cuenta = reader["Numero_cuenta"].ToString(),
                                Id_usuario = Convert.ToInt32(reader["Id_usuario"]),
                                Saldo = Convert.ToDecimal(reader["Saldo"]),
                                Fecha_creacion = Convert.ToDateTime(reader["Fecha_creacion"])
                            };
                        }
                    }
                }
            }

            return null;
        }


        public bool EliminarCuenta(long numeroCuenta)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sqlConsultarSaldo = @"SELECT Saldo FROM Cuenta WHERE Numero_cuenta = @Numero_cuenta";
                string sqlEliminar = @"DELETE FROM Cuenta WHERE Numero_cuenta = @Numero_cuenta";

                conexion.Open();

                using (var comandoConsultar = new SqlCommand(sqlConsultarSaldo, conexion))
                {
                    comandoConsultar.Parameters.AddWithValue("@Numero_cuenta", numeroCuenta);
                    var saldo = comandoConsultar.ExecuteScalar();

                    if (saldo != null && Convert.ToDecimal(saldo) > 50000)
                    {
                        return false;
                    }
                }

                using (var comandoEliminar = new SqlCommand(sqlEliminar, conexion))
                {
                    comandoEliminar.Parameters.AddWithValue("@Numero_cuenta", numeroCuenta);
                    int filasAfectadas = comandoEliminar.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }
        public void ActualizarSaldo(string numeroCuenta, decimal saldo)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = "UPDATE Cuenta SET Saldo = @Saldo WHERE Numero_cuenta = @Numero_cuenta";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Saldo", saldo);
                    comando.Parameters.AddWithValue("@Numero_cuenta", numeroCuenta);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }


    }
}
