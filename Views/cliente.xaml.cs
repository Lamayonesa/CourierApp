
using MiAppMaui.Models;
using MiAppMaui.Services;

namespace MiAppMaui.Views;

public partial class cliente : ContentPage
{
    private readonly MemoriaService _memoriaService;

    public cliente(MemoriaService memoriaService)
    {
        InitializeComponent();

        _memoriaService = memoriaService;
        ClientesCollection.ItemsSource = _memoriaService.Clientes;
    }

    private void OnRegistrarClicked(object sender, EventArgs e)
    {
        string nombre = NombreEntry.Text?.Trim() ?? string.Empty;
        string telefono = TelefonoEntry.Text?.Trim() ?? string.Empty;
        string direccion = DireccionEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(nombre) ||
            string.IsNullOrWhiteSpace(telefono) ||
            string.IsNullOrWhiteSpace(direccion))
        {
            DisplayAlert("Campos obligatorios",
                "Completa todos los campos antes de registrar.",
                "Aceptar");
            return;
        }

        var clienteNuevo = new Cliente
        {
            Nombre = nombre,
            Telefono = telefono,
            Direccion = direccion
        };

        _memoriaService.AgregarCliente(clienteNuevo);

        ClientesCollection.ItemsSource = null;
        ClientesCollection.ItemsSource = _memoriaService.Clientes;

        NombreEntry.Text = string.Empty;
        TelefonoEntry.Text = string.Empty;
        DireccionEntry.Text = string.Empty;
    }
}
