
namespace MiAppMaui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Paquetes), typeof(Paquetes));
        Routing.RegisterRoute(nameof(ConfigUser), typeof(ConfigUser));
    }
}
