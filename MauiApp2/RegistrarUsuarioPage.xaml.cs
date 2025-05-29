using MauiApp2.Datos;
using MauiApp2.Modelos;

namespace MauiApp2;

public partial class RegistrarUsuarioPage : ContentPage
{
    private readonly UsuarioDatabase _usuarioDb = new();

    public RegistrarUsuarioPage()
    {
        InitializeComponent();
    }

    private async void RegistrarseButton_Clicked(object sender, EventArgs e)
    {
        var nombreUsuario = UsuarioEntry.Text?.Trim();
        var correo = CorreoEntry.Text?.Trim(); // Si decides usarlo en el modelo
        var contrase�a = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrase�a))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos obligatorios.", "OK");
            return;
        }

        var usuarioExistente = await _usuarioDb.ObtenerUsuarioAsync(nombreUsuario);
        if (usuarioExistente != null)
        {
            await DisplayAlert("Error", "El nombre de usuario ya existe.", "OK");
            return;
        }

        var nuevoUsuario = new Usuario
        {
            NombreUsuario = nombreUsuario,
            Contrase�a = contrase�a
            // Si agregas correo al modelo, tambi�n: CorreoElectronico = correo
        };

        await _usuarioDb.GuardarUsuarioAsync(nuevoUsuario);

        await DisplayAlert("�xito", "Usuario registrado correctamente.", "OK");
        await Navigation.PopAsync();
    }
}