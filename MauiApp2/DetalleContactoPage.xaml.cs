namespace MauiApp2;

public partial class DetalleContactoPage : ContentPage
{
    private dynamic contacto;

    public DetalleContactoPage(dynamic contactoSeleccionado)
    {
        InitializeComponent();
        contacto = contactoSeleccionado;

        NombreLabel.Text = contacto.Nombre;
        TelefonoLabel.Text = contacto.Telefono;
        CorreoLabel.Text = contacto.Correo;
        DireccionLabel.Text = contacto.Direccion;
    }
}