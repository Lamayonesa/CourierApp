
using System.Collections.ObjectModel;
using MiAppMaui.Models;

namespace MiAppMaui.Services;

public static class MemoriaService
{
    // Contadores para asignar los ID
    private static int _siguienteIdCliente = 1;
    private static int _siguienteIdPaquete = 1;
    private static int _siguienteIdTracking = 1;
    private static int _siguienteIdVehiculo = 1;

    // Colecciones observables
    public static ObservableCollection<Cliente> Clientes { get; }
        = new();

    public static ObservableCollection<MiAppMaui.Models.Paquetes> Paquetes { get; }
        = new();

    public static ObservableCollection<Tracking> Trackings { get; }
        = new();

    public static ObservableCollection<Vehiculos> Vehiculos { get; }
        = new();

    // Método para agregar clientes
    public static void AgregarCliente(Cliente cliente)
    {
        cliente.Id = _siguienteIdCliente++;
        Clientes.Add(cliente);
    }

    // Método para agregar paquetes
    public static void AgregarPaquetes(MiAppMaui.Models.Paquetes paquete)
    {
        paquete.Id = _siguienteIdPaquete++;
        Paquetes.Add(paquete);
    }

    // Método para agregar tracking
    public static void AgregarTracking(Tracking tracking)
    {
        tracking.Id = _siguienteIdTracking++;
        Trackings.Add(tracking);
    }

    // Método para agregar vehículos
    public static void AgregarVehiculos(Vehiculos vehiculo)
    {
        vehiculo.Id = _siguienteIdVehiculo++;
        Vehiculos.Add(vehiculo);
    }
}
