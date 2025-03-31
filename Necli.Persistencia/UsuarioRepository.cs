using System;
using Microsoft.Data.SqlClient;
using Necli.Entidades;

namespace Necli.Persistencia
{
    public class UsuarioRepository
    {
        private readonly string _cadena_conexion = "Server=Manuel_Narvaez\\SQLEXPRESS; Database=Necli; User ID=sa; Password=cecar; TrustServerCertificate=True;";

        public int ObtenerNuevoId()
        {
            int nuevoId = 1;

            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = "SELECT ISNULL(MAX(Id_Usuario), 0) + 1 FROM Usuario";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                }
            }

            return nuevoId;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            usuario.Id_usuarios = ObtenerNuevoId();

            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"INSERT INTO Usuario (Id_Usuario, Nombres, Apellidos, Email,Contrasena,Telefono) 
                               VALUES (@Id_Usuario, @Nombres, @Apellidos, @Email,  @Contrasena,@Telefono)";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id_Usuario", usuario.Id_usuarios);
                    comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    comando.Parameters.AddWithValue("@Email", usuario.Email);
                    comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    comando.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            Usuario usuario = null;

            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"SELECT Id_Usuario, Nombres, Apellidos, Email, Contrasena ,Telefono
                FROM Usuario 
                WHERE Email = @Email";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Email", email);

                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            usuario = new Usuario
                            {
                                Id_usuarios = (int)lector["Id_Usuario"],
                                Nombres = lector["Nombres"].ToString(),
                                Apellidos = lector["Apellidos"].ToString(),
                                Email = lector["Email"].ToString(),
                                Contrasena = lector["Contrasena"].ToString(),
                                Telefono = lector["Telefono"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }
        public Usuario ConsultarContrasenaUsuario(string contrasena, int idUsuarioActual)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"SELECT Id_usuario, Nombres, Apellidos, Email, Contrasena, Telefono 
                       FROM Usuario 
                       WHERE Contrasena = @Contrasena 
                       AND Id_usuario <> @IdUsuarioActual";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Contrasena", contrasena);
                    comando.Parameters.AddWithValue("@IdUsuarioActual", idUsuarioActual);
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id_usuarios = Convert.ToInt32(reader["Id_usuario"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Email = reader["Email"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }


        public Usuario ConsultarUsuarioPorTelefono(string telefono)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = "SELECT Id_usuario, Nombres, Apellidos, Email, Contrasena, Telefono FROM Usuario WHERE Telefono = @Telefono";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    conexion.Open();
                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id_usuarios = Convert.ToInt32(reader["Id_usuario"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Email = reader["Email"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Usuario ConsultarUsuarioPorIdentificacion(long identificacion)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = "SELECT Id_usuario, Nombres, Apellidos, Email, Contrasena, Telefono FROM Usuario WHERE Id_usuario = @Identificacion";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Identificacion", identificacion);
                    conexion.Open();

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id_usuarios = Convert.ToInt32(reader["Id_usuario"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString(),
                                Email = reader["Email"].ToString(),
                                Contrasena = reader["Contrasena"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }




        public bool ActualizarUsuario(int Id_usuario, string Nombres, string Apellidos, string Email, string Contrasena, string Telefono)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                string sql = @"UPDATE Usuario 
                       SET Nombres = @Nombres, 
                           Apellidos = @Apellidos, 
                           Email = @Email,  
                           Contrasena = HASHBYTES('SHA2_256', @Contrasena), -- Seguridad mejorada
                           Telefono = @Telefono
                       WHERE Id_usuario = @Id_usuario";

                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    comando.Parameters.AddWithValue("@Nombres", Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", Apellidos);
                    comando.Parameters.AddWithValue("@Email", Email);
                    comando.Parameters.AddWithValue("@Contrasena", Contrasena);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }







    }
}
