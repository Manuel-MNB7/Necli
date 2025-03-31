namespace Necli.LogicaNegocio.DTOs
{
    public record RegistroUsuarioDto(
        int Id_usuario,
        string Nombres,
        string Apellidos,
        string Email,
        string Contrasena,
        string Telefono

        );

    
}
