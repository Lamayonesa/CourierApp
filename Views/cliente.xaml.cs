
using MiAppMaui.ViewModels;

namespace MiAppMaui.Views;

public partial class cliente : ContentPage
{
    public cliente()
    {
        InitializeComponent();

        // Conectamos el XAML con el ViewModel
        BindingContext = new ClienteFormViewModel();
    }
}
