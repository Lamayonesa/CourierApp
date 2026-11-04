using MiAppMaui.ViewModels;

namespace MiAppMaui.Views;

public partial class Vehiculo : ContentPage
{
    public Vehiculo()
    {
        InitializeComponent();
        BindingContext = new VehiculoFormViewModel();
    }
}
