using MauiApp2.Modelos;

namespace MauiApp2;

public partial class DetalleContactoPage : ContentPage
{
    public DetalleContactoPage(Contacto contactoSeleccionado)
    {
        InitializeComponent();
        BindingContext = contactoSeleccionado;
    }
}