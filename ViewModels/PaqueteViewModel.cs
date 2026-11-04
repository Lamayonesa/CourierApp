using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiAppMaui.Models;
using MiAppMaui.Services;

namespace MiAppMaui.ViewModels;

public partial class PaqueteViewModel : ObservableObject
{
    // ObservableProperty genera propiedades que notifican sus cambios a la interfaz.
    [ObservableProperty] private int id;
    [ObservableProperty] private string descripcion = string.Empty;
    [ObservableProperty] private string destinatario = string.Empty;
    [ObservableProperty] private string destino = string.Empty;

    // Mensajes de error para cada campo del formulario.
    [ObservableProperty] private string descripcionError = string.Empty;
    [ObservableProperty] private string destinatarioError = string.Empty;
    [ObservableProperty] private string destinoError = string.Empty;

    // La colección compartida avisa a la lista cuando se registra un paquete.
    public ObservableCollection<MiAppMaui.Models.Paquetes> Paquetes => MemoriaService.Paquetes;

    // RelayCommand genera GuardarCommand para el botón del formulario.
    [RelayCommand]
    private async Task GuardarAsync()
    {
        if (!Validar()) return;

        var registro = new MiAppMaui.Models.Paquetes
        {
            Descripcion = Descripcion.Trim(),
            Destinatario = Destinatario.Trim(),
            Destino = Destino.Trim(),
            Estado = "Pendiente"
        };

        // El servicio asigna el identificador y guarda el registro en memoria.
        MemoriaService.AgregarPaquetes(registro);

        await Shell.Current.DisplayAlertAsync(
            "Paquete registrado",
            "Paquete agregado correctamente.",
            "Aceptar");

        Limpiar();
    }

    // Validamos todos los campos antes de guardar.
    private bool Validar()
    {
        ValidarDescripcion();
        ValidarDestinatario();
        ValidarDestino();

        // All devuelve true cuando todos los mensajes de error están vacíos.
        return new[] { DescripcionError, DestinatarioError, DestinoError }.All(string.IsNullOrEmpty);
    }

    private void ValidarDescripcion()
    {
        DescripcionError = string.IsNullOrWhiteSpace(Descripcion)
            ? "Este campo es obligatorio."
            : string.Empty;
    }

    private void ValidarDestinatario()
    {
        DestinatarioError = string.IsNullOrWhiteSpace(Destinatario)
            ? "Este campo es obligatorio."
            : string.Empty;
    }

    private void ValidarDestino()
    {
        DestinoError = string.IsNullOrWhiteSpace(Destino)
            ? "Este campo es obligatorio."
            : string.Empty;
    }

    // Limpiamos los datos y los errores después de registrar.
    private void Limpiar()
    {
        Id = 0;
        Descripcion = string.Empty;
        Destinatario = string.Empty;
        Destino = string.Empty;

        DescripcionError = string.Empty;
        DestinatarioError = string.Empty;
        DestinoError = string.Empty;
    }
}
