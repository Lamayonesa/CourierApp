
using MiAppMaui.Models;
using MiAppMaui.Services;

namespace MiAppMaui;

public partial class Paquetes : ContentPage
{
    private readonly MemoriaService _memoriaService;

    public Paquetes(MemoriaService memoriaService)
    {
        InitializeComponent();

        _memoriaService = memoriaService;
        PaquetesCollection.ItemsSource = _memoriaService.Paquetes;
    }

    private void OnRegistrarClicked(object sender, EventArgs e)
    {
        string descripcion = DescripcionEntry.Text?.Trim() ?? string.Empty;
        string destinatario = DestinatarioEntry.Text?.Trim() ?? string.Empty;
        string destino = DestinoEntry.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(descripcion) ||
            string.IsNullOrWhiteSpace(destinatario) ||
            string.IsNullOrWhiteSpace(destino))
        {
            DisplayAlertAsync(
                "Campos obligatorios",
                "Completa todos los campos antes de registrar el paquete.",
                "Aceptar");
            return;
        }

        var paqueteNuevo = new MiAppMaui.Models.Paquetes
        {
            Descripcion = descripcion,
            Destinatario = destinatario,
            Destino = destino,
            Estado = "Pendiente"
        };

        _memoriaService.AgregarPaquetes(paqueteNuevo);

        PaquetesCollection.ItemsSource = null;
        PaquetesCollection.ItemsSource = _memoriaService.Paquetes;

        DescripcionEntry.Text = string.Empty;
        DestinatarioEntry.Text = string.Empty;
        DestinoEntry.Text = string.Empty;
    }
}
