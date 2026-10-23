using MiAppMaui.Views;
using MiAppMaui.Models;

namespace MiAppMaui;

public partial class DashboardUser : ContentPage
{
    public DashboardUser()
    {
        InitializeComponent();
    }


    private async void OnPaquetesClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Paquetes));
    }

    private async void OnTrackingClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Tracking));
    }

    private async void OnConfigClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConfigUser));
    }

    private async void OnVehiculoClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Vehiculo));
    }
    
    private async void OnClienteClicked(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(cliente));
    }

}
