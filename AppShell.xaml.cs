using MiAppMaui.Views;
namespace MiAppMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Paquetes), typeof(Paquetes));
        Routing.RegisterRoute(nameof(ConfigUser), typeof(ConfigUser));
        Routing.RegisterRoute(nameof(Vehiculo), typeof(Vehiculo));
        Routing.RegisterRoute(nameof(tracking), typeof(tracking));
        Routing.RegisterRoute(nameof(cliente), typeof(cliente));
    }
}