using SQLite;
using MauiApp2.Modelos;

namespace MauiApp2.Datos;

public class UsuarioDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public UsuarioDatabase()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "agenda.db");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Usuario>().Wait();
    }

    public Task<Usuario?> ObtenerUsuarioAsync(string nombreUsuario)
    {
        return _db.Table<Usuario>().Where(u => u.NombreUsuario == nombreUsuario).FirstOrDefaultAsync();
    }

    public Task<int> GuardarUsuarioAsync(Usuario usuario)
    {
        return usuario.Id != 0 ? _db.UpdateAsync(usuario) : _db.InsertAsync(usuario);
    }
}
