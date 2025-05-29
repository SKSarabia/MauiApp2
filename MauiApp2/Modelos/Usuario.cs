using SQLite;

namespace MauiApp2.Modelos;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public string Contraseña { get; set; } = string.Empty;
    // Puedes agregar más campos si lo necesitas (correo, etc.)
}