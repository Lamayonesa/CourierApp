using MiAppMaui.Models;
using System.Collections.Generic;


namespace MiAppMaui.Services;

public class MemoriaService
{
    public List<Cliente> Clientes { get; private set; } = new();
    public List<MiAppMaui.Models.Paquetes> Paquetes { get; private set; } = new();
    public List<Tracking> Trackings { get; private set; } = new();
    public List<Vehiculos> Vehiculos { get; private set; } = new();

    public void AgregarCliente(Cliente cliente)
    {
        cliente.Id = Clientes.Count + 1;
        Clientes.Add(cliente);
    }

    public void AgregarPaquetes(MiAppMaui.Models.Paquetes paquete)
    {
        paquete.Id = Paquetes.Count + 1;
        Paquetes.Add(paquete);
    }
    public void AgregarTracking(Tracking tracking)
    {
        tracking.Id = Trackings.Count + 1;
        Trackings.Add(tracking);
    }

    public void AgregarVehiculos(Vehiculos vehiculo)
    {
        vehiculo.Id = Vehiculos.Count + 1;
        Vehiculos.Add(vehiculo);
    }
}
