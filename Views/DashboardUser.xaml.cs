
namespace MiAppMaui;

public partial class DashboardUser : ContentPage
{
    public DashboardUser()
    {
        InitializeComponent();
    }

    private async void OnPaquetesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Paquetes));
    }

    private async void OnConfigClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConfigUser));
    }
}
