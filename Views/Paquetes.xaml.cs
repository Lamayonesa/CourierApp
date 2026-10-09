
namespace MiAppMaui;

public partial class Paquetes : ContentPage
{
    public Paquetes()
    {
        InitializeComponent();
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
