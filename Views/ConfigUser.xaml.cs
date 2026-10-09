
namespace MiAppMaui;

public partial class ConfigUser : ContentPage
{
    public ConfigUser()
    {
        InitializeComponent();
    }

    [Obsolete]
    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync(
            "Configuración",
            "Cambios guardados visualmente.",
            "Aceptar");
    }

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
