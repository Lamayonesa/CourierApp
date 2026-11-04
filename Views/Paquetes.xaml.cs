using MiAppMaui.ViewModels;

namespace MiAppMaui;

public partial class Paquetes : ContentPage
{
    public Paquetes()
    {
        InitializeComponent();
        BindingContext = new PaqueteViewModel();
    }
}
