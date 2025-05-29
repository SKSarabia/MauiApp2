using MauiApp2.Datos;
using MauiApp2.Modelos;

namespace MauiApp2;

public partial class LoginFlow : ContentPage
{
    public LoginFlow()
    {
        InitializeComponent();
        VerificarSesion();
    }

    private async void VerificarSesion()
    {
        var hasAuth = await SecureStorage.GetAsync("hasAuth");
        if (hasAuth == "true")
        {
            // Usuario autenticado
            await Navigation.PushAsync(new MainPage());
        }
    }

    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RecuperarContraseñaPage());
    }
    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RegistrarUsuarioPage());
    }

    private readonly UsuarioDatabase _usuarioDb = new();

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (await IsCredentialCorrect(Username.Text, Password.Text))
        {
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            await SecureStorage.SetAsync("hasAuth", "true");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Advertencia", "Usuario o contraseña incorrecto", "Intenta de nuevo");
        }
    }

    private async Task<bool> IsCredentialCorrect(string username, string password)
    {
        var usuario = await _usuarioDb.ObtenerUsuarioAsync(username.Trim());
        return usuario != null && usuario.Contraseña == password;
    }
}