namespace MauiApp2;

public partial class ContactosPage : ContentPage
{
    public static List<object> contactos = new List<object>
    {
        new { Nombre = "Ana López", Telefono = "123-456-7890", Correo = "ana@email.com", Direccion = "Calle 1" },
        new { Nombre = "Carlos Pérez", Telefono = "987-654-3210", Correo = "carlos@email.com", Direccion = "Avenida 5" }
    };

    public ContactosPage()
    {
        InitializeComponent();
        ContactosListView.ItemsSource = contactos;
    }

    private async void IrDetalleContacto(object sender, EventArgs e)
    {
        var contactoSeleccionado = (object)((Button)sender).BindingContext;
        await Navigation.PushAsync(new DetalleContactoPage(contactoSeleccionado));
    }
}