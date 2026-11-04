using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiAppMaui.Models;
using MiAppMaui.Services;

namespace MiAppMaui.ViewModels;

public partial class VehiculoFormViewModel : ObservableObject
{
    // ObservableProperty genera propiedades que notifican sus cambios a la interfaz.
    [ObservableProperty] private int id;
    [ObservableProperty] private string placa = string.Empty;
    [ObservableProperty] private string chasis = string.Empty;

    // Mensajes de error para cada campo del formulario.
    [ObservableProperty] private string placaError = string.Empty;
    [ObservableProperty] private string chasisError = string.Empty;

    // Mostramos la misma colección que utiliza el servicio de memoria.
    public ObservableCollection<Vehiculos> Vehiculos => MemoriaService.Vehiculos;

    // RelayCommand genera GuardarCommand para el botón del formulario.
    [RelayCommand]
    private async Task GuardarAsync()
    {
        if (!Validar()) return;

        var registro = new Vehiculos
        {
            Placa = Placa.Trim(),
            Chasis = Chasis.Trim()
        };

        // El servicio asigna el identificador y guarda el registro en memoria.
        MemoriaService.AgregarVehiculos(registro);

        await Shell.Current.DisplayAlertAsync(
            "Vehículo registrado",
            "Vehículo agregado correctamente.",
            "Aceptar");

        Limpiar();
    }

    // Validamos todos los campos antes de guardar.
    private bool Validar()
    {
        ValidarPlaca();
        ValidarChasis();

        // All devuelve true cuando todos los mensajes de error están vacíos.
        return new[] { PlacaError, ChasisError }.All(string.IsNullOrEmpty);
    }

    private void ValidarPlaca()
    {
        PlacaError = string.IsNullOrWhiteSpace(Placa)
            ? "Este campo es obligatorio."
            : string.Empty;
    }

    private void ValidarChasis()
    {
        ChasisError = string.IsNullOrWhiteSpace(Chasis)
            ? "Este campo es obligatorio."
            : string.Empty;
    }

    // Limpiamos los datos y los errores después de registrar.
    private void Limpiar()
    {
        Id = 0;
        Placa = string.Empty;
        Chasis = string.Empty;

        PlacaError = string.Empty;
        ChasisError = string.Empty;
    }
}
