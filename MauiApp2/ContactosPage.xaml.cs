using MauiApp2.Datos;
using MauiApp2.Modelos;

namespace MauiApp2;

public partial class ContactosPage : ContentPage
{
    private readonly ContactoDatabase _database = new();

    public ContactosPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var contactos = await _database.ObtenerContactosAsync();
        ContactosListView.ItemsSource = contactos;
    }

    private async void IrDetalleContacto(object sender, EventArgs e)
    {
        var contactoSeleccionado = (Contacto)((Button)sender).BindingContext;
        await Navigation.PushAsync(new DetalleContactoPage(contactoSeleccionado));
    }
}
