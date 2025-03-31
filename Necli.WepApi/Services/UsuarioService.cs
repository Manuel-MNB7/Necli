using Necli.WepApi.Entities;

namespace Necli.WepApi.Services
{
    public class UsuarioService
    {
        public static List<Usuario> usuarios = new List<Usuario>
        {
             new Usuario { Id = "1", Nombre = "Juan", Apellidos = "Pérez", Correo = "juanperez@email.com", Numero = "3106436202", Saldo = 11000, Contraseña = "Juan123" },
    new Usuario { Id = "2", Nombre = "María", Apellidos = "Gómez", Correo = "mariagomez@email.com", Numero = "3156784321", Saldo = 20000, Contraseña = "Maria456" },
    new Usuario { Id = "3", Nombre = "Carlos", Apellidos = "Rodríguez", Correo = "carlosr@email.com", Numero = "3209876543", Saldo = 5000, Contraseña = "Carlos789" },
    new Usuario { Id = "4", Nombre = "Ana", Apellidos = "Martínez", Correo = "anamartinez@email.com", Numero = "3221234567", Saldo = 7500, Contraseña = "Ana321" },
    new Usuario { Id = "5", Nombre = "Luis", Apellidos = "Fernández", Correo = "luisf@email.com", Numero = "3114567890", Saldo = 15000, Contraseña = "Luis654" },
    new Usuario { Id = "6", Nombre = "Sofía", Apellidos = "Ramírez", Correo = "sofiar@email.com", Numero = "3132345678", Saldo = 18000, Contraseña = "Sofia987" },
    new Usuario { Id = "7", Nombre = "Pedro", Apellidos = "Torres", Correo = "pedrot@email.com", Numero = "3167891234", Saldo = 12000, Contraseña = "Pedro234" },
    new Usuario { Id = "8", Nombre = "Laura", Apellidos = "Herrera", Correo = "laurah@email.com", Numero = "3194567321", Saldo = 22000, Contraseña = "Laura567" },
    new Usuario { Id = "9", Nombre = "Andrés", Apellidos = "Castro", Correo = "andresc@email.com", Numero = "3101239876", Saldo = 9000, Contraseña = "Andres890" },
    new Usuario { Id = "10", Nombre = "Gabriela", Apellidos = "Méndez", Correo = "gabrielam@email.com", Numero = "3145678901", Saldo = 17000, Contraseña = "Gabriela123" }
};
    }
}
