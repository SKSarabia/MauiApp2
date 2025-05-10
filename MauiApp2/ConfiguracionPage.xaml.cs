namespace MauiApp2;

public partial class ConfiguracionPage : ContentPage
{
    public ConfiguracionPage()
    {
        InitializeComponent();
    }

    private void ActivarNotificaciones(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            DisplayAlert("Notificaciones", "Notificaciones activadas", "OK");
        else
            DisplayAlert("Notificaciones", "Notificaciones desactivadas", "OK");
    }

    private void CambiarTema(object sender, EventArgs e)
    {
        if (App.Current.UserAppTheme == AppTheme.Dark)
        {
            App.Current.UserAppTheme = AppTheme.Light;
            DisplayAlert("Tema", "Modo Claro activado", "OK");
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Dark;
            DisplayAlert("Tema", "Modo Oscuro activado", "OK");
        }
    }

    private async void CerrarSesion(object sender, EventArgs e)
    {
        // Eliminar credenciales
        Preferences.Remove("UsuarioActual");
        SecureStorage.Remove("hasAuth");
        await Navigation.PushAsync(new LoginFlow());
    }
}